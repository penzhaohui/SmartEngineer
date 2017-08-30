using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;

namespace TechTalk.JiraRestClient
{
    //JIRA REST API documentation: https://docs.atlassian.com/jira/REST/latest

    public class JiraClient<TIssueFields> : IJiraClient<TIssueFields> where TIssueFields : IssueFields, new()
    {
        private readonly string username;
        private readonly string password;
        private readonly JsonDeserializer deserializer;
        private readonly string baseApiUrl;
        public JiraClient(string baseUrl, string username, string password)
        {
            this.username = username;
            this.password = password;

            baseApiUrl = new Uri(new Uri(baseUrl), "rest/api/2/").ToString();
            deserializer = new JsonDeserializer();
        }

        private RestRequest CreateRequest(Method method, String path)
        {
            var request = new RestRequest { Method = method, Resource = path, RequestFormat = DataFormat.Json };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", username, password))));
            return request;
        }

        private IRestResponse ExecuteRequest(RestRequest request)
        {
            var client = new RestClient(baseApiUrl);
            return client.Execute(request);
        }

        private void AssertStatus(IRestResponse response, HttpStatusCode status)
        {
            if (response.ErrorException != null)
                throw new JiraClientException("Transport level error: " + response.ErrorMessage, response.ErrorException);
            if (response.StatusCode != status)
                throw new JiraClientException("JIRA returned wrong status: " + response.StatusDescription, response.Content);
        }

        /// Returns the currently logged user
        public JiraUser GetMySelf()
        {
            try
            {
                var path = "myself";
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                return deserializer.Deserialize<JiraUser>(response);
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetMySelf() error: {0}", ex);
                throw new JiraClientException("Could not get jira user", ex);
            }
        }

        public IEnumerable<Issue<TIssueFields>> GetIssues(String projectKey)
        {
            return EnumerateIssues(projectKey, null).ToArray();
        }

        public IEnumerable<Issue<TIssueFields>> GetIssues(String projectKey, String issueType)
        {
            return EnumerateIssues(projectKey, issueType).ToArray();
        }

        public IEnumerable<Issue<TIssueFields>> GetIssuesByQuery(string projectKey, string issueType, string jqlQuery)
        {
            return EnumerateIssuesInternal(projectKey, issueType, jqlQuery);
        }

        public IEnumerable<Issue<TIssueFields>> EnumerateIssues(String projectKey)
        {
            return EnumerateIssues(projectKey, null);
        }

        public IEnumerable<Issue<TIssueFields>> EnumerateIssues(String projectKey, String issueType)
        {
            try
            {
                return EnumerateIssuesInternal(projectKey, issueType);
            }
            catch (Exception ex)
            {
                Trace.TraceError("EnumerateIssues(projectKey, issueType) error: {0}", ex);
                throw new JiraClientException("Could not load issues", ex);
            }
        }

        private IEnumerable<Issue<TIssueFields>> EnumerateIssuesInternal(String projectKey, String issueType, String jqlQuery = null)
        {
            var queryCount = 50;
            var resultCount = 0;
            while (true)
            {
                var jql = "";
                if (projectKey!="")
                    jql = String.Format("project={0}+AND+", Uri.EscapeUriString(projectKey));
                if (!String.IsNullOrEmpty(issueType))
                    jql += String.Format("issueType={0}+AND+", Uri.EscapeUriString(issueType));
                if (!String.IsNullOrEmpty(jqlQuery))
                    jql += String.Format("{0}", Uri.EscapeUriString(jqlQuery));
                var path = String.Format("search?jql={0}&startAt={1}&maxResults={2}", jql, resultCount, queryCount);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<IssueContainer<TIssueFields>>(response);
                var issues = data.issues ?? Enumerable.Empty<Issue<TIssueFields>>();

                foreach (var item in issues) yield return item;
                resultCount += issues.Count();

                if (resultCount < data.total) continue;
                else /* all issues received */ break;
            }
        }

        public Issue<TIssueFields> LoadIssue(IssueRef issueRef)
        {
            return LoadIssue(issueRef.JiraIdentifier);
        }

        public Issue<TIssueFields> LoadIssue(String issueRef)
        {
            try
            {
                var path = String.Format("issue/{0}", issueRef);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var issue = deserializer.Deserialize<Issue<TIssueFields>>(response);
                issue.fields.comments = GetComments(issue).ToList();
                issue.fields.watchers = GetWatchers(issue).ToList();
                Issue.ExpandLinks(issue);
                return issue;
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetIssue(issueRef) error: {0}", ex);
                throw new JiraClientException("Could not load issue", ex);
            }
        }

        // https://developer.atlassian.com/jiradev/jira-apis/jira-rest-apis/jira-rest-api-tutorials/jira-rest-api-example-create-issue
        public Issue<TIssueFields> CreateSubTask(String projectKey, String parent, String summary, string description)
        {
            try
            {
                var request = CreateRequest(Method.POST, "issue");
                request.AddHeader("ContentType", "application/json");

                var issueData = new Dictionary<string, object>();
                issueData.Add("project", new { key = projectKey });
                issueData.Add("parent", new { key = parent });
                issueData.Add("issuetype", new { id = 5 });
                //issueData.Add("issuetype", new { name = "Sub-task" });
                issueData.Add("summary", summary);                
                issueData.Add("description", description);
                issueData.Add("customfield_11506", 0);

                request.AddBody(new { fields = issueData });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.Created);

                var issueRef = deserializer.Deserialize<IssueRef>(response);
                return LoadIssue(issueRef);
            }
            catch (Exception ex)
            {               
                Trace.TraceError("CreateIssue(projectKey, typeCode) error: {0}", ex);
                throw new JiraClientException("Could not create issue", ex);
            }
        }


        public Issue<TIssueFields> UpdateSubTask(String projectKey, Issue<TIssueFields> issue)
        {
            try
            {
                var path = String.Format("issue/{0}", issue.JiraIdentifier);
                var request = CreateRequest(Method.PUT, path);
                request.AddHeader("ContentType", "application/json");

                var updateData = new Dictionary<string, object>();         
                updateData.Add("summary", new[] { new { set = issue.fields.summary } });
                updateData.Add("description", new[] { new { set = issue.fields.description } });
                updateData.Add("assignee", new[] { new { set = new { name = issue.fields.assignee.name } } });               

                request.AddBody(new { update = updateData });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);

                return LoadIssue(issue);
            }
            catch (Exception ex)
            {
                Trace.TraceError("UpdateIssue(issue) JIRA Issue Key: {0}", issue.key);
                Trace.TraceError("UpdateIssue(issue) error: {0}", ex);
                throw new JiraClientException("Could not update issue", ex);
            }
        }
        public Issue<TIssueFields> CreateIssue(String projectKey, String issueType, String summary)
        {
            return CreateIssue(projectKey, issueType, new TIssueFields { summary = summary });
        }

        public Issue<TIssueFields> CreateIssue(String projectKey, String issueType, TIssueFields issueFields)
        {
            try
            {
                var request = CreateRequest(Method.POST, "issue");
                request.AddHeader("ContentType", "application/json");

                var issueData = new Dictionary<string, object>();
                issueData.Add("project", new { key = projectKey });
                issueData.Add("issuetype", new { name = issueType });

                if (issueFields.summary != null)
                    issueData.Add("summary", issueFields.summary);
                if (issueFields.description != null)
                    issueData.Add("description", issueFields.description);
                if (issueFields.labels != null)
                    issueData.Add("labels", issueFields.labels);
                if (issueFields.Priority != null)
                    issueData.Add("priority", new[] { new { set = new { name = issueFields.Priority.name } } });
                //if (issueFields.timetracking != null)
                //issueData.Add("timetracking", new { originalEstimate = issueFields.timetracking.originalEstimate });

                if ("DATABASE" != projectKey)
                {
                    var propertyList = typeof(TIssueFields).GetProperties().Where(p => p.Name.StartsWith("customfield_"));
                    foreach (var property in propertyList)
                    {
                        var value = property.GetValue(issueFields, null);
                        if (value != null) issueData.Add(property.Name, value);

                        /*
                        var propertyNalue = property.GetValue(issueFields, null);
                        if (propertyNalue != null)
                        {
                            // SF-Priority
                            if ("customfield_10905" == property.Name)
                            {
                                issueData.Add(property.Name, new[] { new { set = new { value = propertyNalue } } });
                            }
                            // Severity
                            else if ("customfield_11106" == property.Name)
                            {
                                issueData.Add(property.Name, new[] { new { set = new { value = (propertyNalue as IssueSeverity).name } } });
                            }
                            // JIRA-Product
                            else if ("customfield_11501" == property.Name)
                            {
                                issueData.Add(property.Name, new[] { new { set = new[] { new { value = propertyNalue } } } });
                            }
                            else
                            {
                                issueData.Add(property.Name, new[] { new { set = propertyNalue } });
                            }
                        }
                         * */
                    }
                }

                request.AddBody(new { fields = issueData });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.Created);

                var issueRef = deserializer.Deserialize<IssueRef>(response);
                return LoadIssue(issueRef);
            }
            catch (Exception ex)
            {
                Trace.TraceError("CreateIssue(projectKey, typeCode) Salesforce Number: {0}", issueFields.customfield_10600);
                Trace.TraceError("CreateIssue(projectKey, typeCode) error: {0}", ex);
                throw new JiraClientException("Could not create issue", ex);
            }
        }

        public Issue<TIssueFields> UpdateIssue(Issue<TIssueFields> issue)
        {
            try
            {
                var path = String.Format("issue/{0}", issue.JiraIdentifier);
                var request = CreateRequest(Method.PUT, path);
                request.AddHeader("ContentType", "application/json");

                var updateData = new Dictionary<string, object>();
                if (issue.fields.summary != null)
                    updateData.Add("summary", new[] { new { set = issue.fields.summary } });
                if (issue.fields.description != null)
                    updateData.Add("description", new[] { new { set = issue.fields.description } });
                if (issue.fields.labels != null)
                    updateData.Add("labels", new[] { new { set = issue.fields.labels } });
                if (issue.fields.Priority != null)
                    updateData.Add("priority", new[] { new { set = new { name = issue.fields.Priority.name } } });
                //if (issue.fields.timetracking != null)
                //    updateData.Add("timetracking", new[] { new { set = new { originalEstimate = issue.fields.timetracking.originalEstimate } } });

                if (issue.key.StartsWith("ENGSUPP"))
                {
                    var propertyList = typeof(TIssueFields).GetProperties().Where(p => p.Name.StartsWith("customfield_"));
                    foreach (var property in propertyList)
                    {
                        var propertyValue = property.GetValue(issue.fields, null);
                        if (propertyValue != null)
                        {
                            // SF-Priority & Issue Category
                            if ("customfield_10905" == property.Name || "customfield_11502" == property.Name)
                            {
                                //updateData.Add(property.Name, new[] { new { set = new { value = propertyNalue } } });
                            }
                            // SF-Case Comment Count
                            else if ("customfield_12400" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = (int)propertyValue } });
                            }
                            // SF-Last Modified
                            else if ("customfield_10903" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = (propertyValue as string) } });
                            }
                            // Severity
                            else if ("customfield_11106" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = new { value = (propertyValue as IssueSeverity).name, id = "" + (propertyValue as IssueSeverity).id } } });
                            }
                            // JIRA-Product
                            else if ("customfield_11501" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = new[] { new { value = propertyValue } } } });
                            }
                            // SF-Origin
                            else if ("customfield_11900" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = new { value = propertyValue } } });
                            }
                            // SF-Customer
                            else if ("customfield_10900" == property.Name)
                            {
                                updateData.Add(property.Name, new[] { new { set = propertyValue } });
                            }
                            else
                            {
                                updateData.Add(property.Name, new[] { new { set = propertyValue } });
                            }
                        }
                    }
                }

                request.AddBody(new { update = updateData });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);

                return LoadIssue(issue);
            }
            catch (Exception ex)
            {
                Trace.TraceError("UpdateIssue(issue) JIRA Issue Key: {0}", issue.key);
                Trace.TraceError("UpdateIssue(issue) error: {0}", ex);
                throw new JiraClientException("Could not update issue", ex);
            }
        }

        public void DeleteIssue(IssueRef issue)
        {
            try
            {
                var path = String.Format("issue/{0}?deleteSubtasks=true", issue.id);
                var request = CreateRequest(Method.DELETE, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DeleteIssue(issue) error: {0}", ex);
                throw new JiraClientException("Could not delete issue", ex);
            }
        }


        public IEnumerable<Transition> GetTransitions(IssueRef issue)
        {
            try
            {
                var path = String.Format("issue/{0}/transitions?expand=transitions.fields", issue.id);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<TransitionsContainer>(response);
                return data.transitions;
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetTransitions(issue) error: {0}", ex);
                throw new JiraClientException("Could not load issue transitions", ex);
            }
        }

        // https://www.quora.com/How-could-I-close-JIRA-ticket-using-rest-API
        public Issue<TIssueFields> TransitionIssue(IssueRef issue, Transition transition)
        {
            try
            {
                var path = String.Format("issue/{0}/transitions", issue.id);
                var request = CreateRequest(Method.POST, path);
                request.AddHeader("ContentType", "application/json");

                var update = new Dictionary<string, object>();
                update.Add("transition", new { id = transition.id });
                //update.Add("resolution", new[] { new { set = issue.fields.summary } });
                //update.Add("resolution", new[] { new { set = new { name = "Done", id = 10000 } } });
                update.Add("resolution", new[] { new { set = new { value = "Done" } } });
                update.Add("customfield_12500", new[] { new { set = new { name = "Others", id = 12010 } } });
                //if (transition.fields != null)
                //    update.Add("fields", transition.fields);

                request.AddBody(update);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);

                return LoadIssue(issue);
            }
            catch (Exception ex)
            {
                Trace.TraceError("TransitionIssue(issue, transition) error: {0}", ex);
                throw new JiraClientException("Could not transition issue state", ex);
            }
        }


        public IEnumerable<JiraUser> GetWatchers(IssueRef issue)
        {
            try
            {
                var path = String.Format("issue/{0}/watchers", issue.id);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                return deserializer.Deserialize<WatchersContainer>(response).watchers;
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetWatchers(issue) error: {0}", ex);
                throw new JiraClientException("Could not load watchers", ex);
            }
        }


        public IEnumerable<Comment> GetComments(IssueRef issue)
        {
            try
            {
                var path = String.Format("issue/{0}/comment", issue.id);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<CommentsContainer>(response);
                return data.comments ?? Enumerable.Empty<Comment>();
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetComments(issue) error: {0}", ex);
                throw new JiraClientException("Could not load comments", ex);
            }
        }

        public IEnumerable<Worklog> GetWorklogs(IssueRef issue)
        {
            try
            {
                var path = String.Format("issue/{0}/worklog", issue.id);
                var request = CreateRequest(Method.GET, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<WorklogsContainer>(response);
                return data.worklogs ?? Enumerable.Empty<Worklog>();
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetComments(issue) error: {0}", ex);
                throw new JiraClientException("Could not load comments", ex);
            }
        }

        public Comment CreateComment(IssueRef issue, String comment)
        {
            try
            {
                var path = String.Format("issue/{0}/comment", issue.id);
                var request = CreateRequest(Method.POST, path);
                request.AddHeader("ContentType", "application/json");
                request.AddBody(new Comment { body = comment });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.Created);

                return deserializer.Deserialize<Comment>(response);
            }
            catch (Exception ex)
            {
                Trace.TraceError("CreateComment(issue, comment) error: {0}", ex);
                throw new JiraClientException("Could not create comment", ex);
            }
        }

        public void DeleteComment(IssueRef issue, Comment comment)
        {
            try
            {
                var path = String.Format("issue/{0}/comment/{1}", issue.id, comment.id);
                var request = CreateRequest(Method.DELETE, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DeleteComment(issue, comment) error: {0}", ex);
                throw new JiraClientException("Could not delete comment", ex);
            }
        }


        public IEnumerable<Attachment> GetAttachments(IssueRef issue)
        {
            return LoadIssue(issue).fields.attachment;
        }

        public Attachment CreateAttachment(IssueRef issue, byte[] fileStream, String fileName)
        {
            try
            {
                var path = String.Format("issue/{0}/attachments", issue.id);
                var request = CreateRequest(Method.POST, path);
                request.AddHeader("X-Atlassian-Token", "nocheck");
                request.AddHeader("ContentType", "multipart/form-data");
                //request.AddFile("file", stream => fileStream.CopyTo(stream), fileName);
                request.AddFile("file", fileStream, fileName);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                return deserializer.Deserialize<List<Attachment>>(response).Single();
            }
            catch (Exception ex)
            {
                Trace.TraceError("CreateAttachment(issue, fileStream, fileName) error: {0}", ex);
                throw new JiraClientException("Could not create attachment", ex);
            }
        }

        public void DeleteAttachment(Attachment attachment)
        {
            try
            {
                var path = String.Format("attachment/{0}", attachment.id);
                var request = CreateRequest(Method.DELETE, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DeleteAttachment(attachment) error: {0}", ex);
                throw new JiraClientException("Could not delete attachment", ex);
            }
        }


        public IEnumerable<IssueLink> GetIssueLinks(IssueRef issue)
        {
            return LoadIssue(issue).fields.issuelinks;
        }

        public IssueLink LoadIssueLink(IssueRef parent, IssueRef child, String relationship)
        {
            try
            {
                var issue = LoadIssue(parent);
                var links = issue.fields.issuelinks
                    .Where(l => l.type.name == relationship)
                    .Where(l => l.inwardIssue.id == parent.id)
                    .Where(l => l.outwardIssue.id == child.id)
                    .ToArray();

                if (links.Length > 1)
                    throw new JiraClientException("Ambiguous issue link");
                return links.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError("LoadIssueLink(parent, child, relationship) error: {0}", ex);
                throw new JiraClientException("Could not load issue link", ex);
            }
        }

        public IssueLink CreateIssueLink(IssueRef parent, IssueRef child, String relationship)
        {
            try
            {
                var request = CreateRequest(Method.POST, "issueLink");
                request.AddHeader("ContentType", "application/json");
                request.AddBody(new
                {
                    type = new { name = relationship },
                    inwardIssue = new { id = parent.id },
                    outwardIssue = new { id = child.id }
                });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.Created);

                return LoadIssueLink(parent, child, relationship);
            }
            catch (Exception ex)
            {
                Trace.TraceError("CreateIssueLink(parent, child, relationship) error: {0}", ex);
                throw new JiraClientException("Could not link issues", ex);
            }
        }

        public void DeleteIssueLink(IssueLink link)
        {
            try
            {
                var path = String.Format("issueLink/{0}", link.id);
                var request = CreateRequest(Method.DELETE, path);

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DeleteIssueLink(link) error: {0}", ex);
                throw new JiraClientException("Could not delete issue link", ex);
            }
        }


        public IEnumerable<RemoteLink> GetRemoteLinks(IssueRef issue)
        {
            try
            {
                var path = string.Format("issue/{0}/remotelink", issue.id);
                var request = CreateRequest(Method.GET, path);
                request.AddHeader("ContentType", "application/json");

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                return deserializer.Deserialize<List<RemoteLinkResult>>(response)
                    .Select(RemoteLink.Convert).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetRemoteLinks(issue) error: {0}", ex);
                throw new JiraClientException("Could not load external links for issue", ex);
            }
        }

        public RemoteLink CreateRemoteLink(IssueRef issue, RemoteLink remoteLink)
        {
            try
            {
                var path = string.Format("issue/{0}/remotelink", issue.id);
                var request = CreateRequest(Method.POST, path);
                request.AddHeader("ContentType", "application/json");
                request.AddBody(new
                {
                    application = new
                    {
                        type = "TechTalk.JiraRestClient",
                        name = "JIRA REST client"
                    },
                    @object = new
                    {
                        url = remoteLink.url,
                        title = remoteLink.title,
                        summary = remoteLink.summary
                    }
                });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.Created);

                //returns: { "id": <id>, "self": <url> }
                var linkId = deserializer.Deserialize<RemoteLink>(response).id;
                return GetRemoteLinks(issue).Single(rl => rl.id == linkId);
            }
            catch (Exception ex)
            {
                Trace.TraceError("CreateRemoteLink(issue, remoteLink) error: {0}", ex);
                throw new JiraClientException("Could not create external link for issue", ex);
            }
        }

        public RemoteLink UpdateRemoteLink(IssueRef issue, RemoteLink remoteLink)
        {
            try
            {
                var path = string.Format("issue/{0}/remotelink/{1}", issue.id, remoteLink.id);
                var request = CreateRequest(Method.PUT, path);
                request.AddHeader("ContentType", "application/json");

                var updateData = new Dictionary<string, object>();
                if (remoteLink.url != null) updateData.Add("url", remoteLink.url);
                if (remoteLink.title != null) updateData.Add("title", remoteLink.title);
                if (remoteLink.summary != null) updateData.Add("summary", remoteLink.summary);
                request.AddBody(new { @object = updateData });

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);

                return GetRemoteLinks(issue).Single(rl => rl.id == remoteLink.id);
            }
            catch (Exception ex)
            {
                Trace.TraceError("UpdateRemoteLink(issue, remoteLink) error: {0}", ex);
                throw new JiraClientException("Could not update external link for issue", ex);
            }
        }

        public void DeleteRemoteLink(IssueRef issue, RemoteLink remoteLink)
        {
            try
            {
                var path = string.Format("issue/{0}/remotelink/{1}", issue.id, remoteLink.id);
                var request = CreateRequest(Method.DELETE, path);
                request.AddHeader("ContentType", "application/json");

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                Trace.TraceError("DeleteRemoteLink(issue, remoteLink) error: {0}", ex);
                throw new JiraClientException("Could not delete external link for issue", ex);
            }
        }

        public IEnumerable<IssueType> GetIssueTypes()
        {
            try
            {
                var request = CreateRequest(Method.GET, "issuetype");
                request.AddHeader("ContentType", "application/json");

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                var data = deserializer.Deserialize<List<IssueType>>(response);
                return data;

            }
            catch (Exception ex)
            {
                Trace.TraceError("GetIssueTypes() error: {0}", ex);
                throw new JiraClientException("Could not load issue types", ex);
            }
        }

        public ServerInfo GetServerInfo()
        {
            try
            {
                var request = CreateRequest(Method.GET, "serverInfo");
                request.AddHeader("ContentType", "application/json");

                var response = ExecuteRequest(request);
                AssertStatus(response, HttpStatusCode.OK);

                return deserializer.Deserialize<ServerInfo>(response);
            }
            catch (Exception ex)
            {
                Trace.TraceError("GetServerInfo() error: {0}", ex);
                throw new JiraClientException("Could not retrieve server information", ex);
            }
        }
    }
}
