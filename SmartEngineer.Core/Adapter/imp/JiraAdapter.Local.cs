using SmartEngineer.Core.DAOs;
using SmartEngineer.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Adapter
{
    public partial class JiraAdapter : IJiraAdapter
    {
        private static readonly IJiraIssueDAO<JiraIssue> JiraIssueDAO = new JiraIssueDAO<JiraIssue>();
        private static readonly IJiraIssueCommentDAO<JiraIssueComment> JiraIssueCommentDAO = new JiraIssueCommentDAO<JiraIssueComment>();
        private static readonly IJiraSubTaskDAO<JiraSubTask> JiraSubTaskDAO = new JiraSubTaskDAO<JiraSubTask>();
        private static readonly IJiraWorkLogDAO<JiraWorkLog> JiraWorkLogDAO = new JiraWorkLogDAO<JiraWorkLog>();

        private static readonly string JiraAccount = ConfigurationManager.AppSettings["JiraAccount"];
        private static readonly string JiraPassword = ConfigurationManager.AppSettings["JiraPassword"];

        public List<JiraIssue> GetIssueInfoByCaseNos(List<string> caseNos)
        {
            return JiraIssueDAO.GetEntitiesByCaseNo(caseNos);
        }

        public List<JiraIssue> GetIssueInfoByJiraKeys(List<string> jiraKeys)
        {
            return JiraIssueDAO.GetEntitiesByJiraKey(jiraKeys);
        }

        public bool IsExistsLocalIssue(string jiraKey)
        {
            return JiraIssueDAO.IsExist(new { JiraKey = jiraKey });
        }

        public bool IsExistsLocalCase(string caseNo)
        {
            return JiraIssueDAO.IsExist(new { CaseNumber = caseNo });
        }

        public List<string> BatchStoreIssueInfoToLocal(List<string> caseNOs)
        {
            List<string> jiraKeyList = new List<string>();
  
            if (caseNOs.Count == 0) return jiraKeyList;

            List<Issue> issues = PullIssueList(caseNOs, JiraAccount, JiraPassword);

            foreach (Issue issue in issues)
            {
                try
                {
                    JiraIssue issueInfo = new JiraIssue();
                    issueInfo.Initialize(issue);
                    StoreIssueInfoToLocal(issueInfo);

                    jiraKeyList.Add(issueInfo.JiraKey);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Logger.Error($"Encouter one exception while executing the function BatchStoreIssueInfoToLocal, the detailed message {ex.Message}");
                }
            }

            return jiraKeyList;
        }

        public async Task<bool> BatchStoreIssueInfoToLocalSync(List<string> caseNOs)
        {
            return await Task.Run(() =>
            {
                try
                {
                    List<string> jiraKeyList = BatchStoreIssueInfoToLocal(caseNOs);

                    BatchStoreIssueCommentToLocal(jiraKeyList);
                    BatchStoreSubTaskToLocal(jiraKeyList);
                    BatchStoreWorkLogToLocal(jiraKeyList);
                }
                catch (Exception ex)
                {
                    Logger.Error("Failed to store issue info to local.", ex);
                }

                return true;
            });
        }

        public bool BatchStoreIssueCommentToLocal(List<string> jiraKeys)
        {
            if (jiraKeys == null || jiraKeys.Count == 0) return false;

            List<JiraIssue> jiraIssueList = GetIssueInfoByJiraKeys(jiraKeys);
            foreach (JiraIssue jiraIssue in jiraIssueList)
            {
                IssueRef issueRef = new IssueRef();
                issueRef.key = jiraIssue.JiraKey;
                issueRef.id = jiraIssue.JiraID;

                try
                {
                    List<Comment> comments = PullComments(issueRef, JiraAccount, JiraPassword);
                    foreach (Comment comment in comments)
                    {
                        JiraIssueComment jiraIssueComment = new JiraIssueComment();
                        jiraIssueComment.Initialize(jiraIssue.JiraKey, comment);

                        if (!JiraIssueCommentDAO.IsExist(jiraIssueComment))
                        {
                            JiraIssueCommentDAO.Insert(jiraIssueComment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to store issue comment info to local for jira key {jiraIssue.JiraKey}.", ex);
                }
            }

            return true;
        }

        public bool BatchStoreSubTaskToLocal(List<string> jiraKeys)
        {
            if (jiraKeys == null || jiraKeys.Count == 0) return false;

            List<JiraIssue> jiraIssueList = GetIssueInfoByJiraKeys(jiraKeys);
            foreach (JiraIssue jiraIssue in jiraIssueList)
            {
                IssueRef issueRef = new IssueRef();
                issueRef.key = jiraIssue.JiraKey;
                issueRef.id = jiraIssue.JiraID;

                try
                {
                    List<SubTask> subTasks = PullSubTasks(issueRef, JiraAccount, JiraPassword);
                    foreach (SubTask subTask in subTasks)
                    {
                        JiraSubTask jiraSubTask = new JiraSubTask();
                        jiraSubTask.Initialize(subTask);

                        if (!JiraSubTaskDAO.IsExist(jiraSubTask))
                        {
                            JiraSubTaskDAO.Insert(jiraSubTask);
                        }
                        else
                        {
                            JiraSubTaskDAO.Update(jiraSubTask);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to store sub task info to local for jira key {jiraIssue.JiraKey}.", ex);
                }
            }

            return true;
        }

        public bool BatchStoreWorkLogToLocal(List<string> jiraKeys)
        {
            if (jiraKeys == null || jiraKeys.Count == 0) return false;

            List<Worklog> workLogs = null;
           List <JiraIssue> jiraIssueList = GetIssueInfoByJiraKeys(jiraKeys);
            foreach (JiraIssue jiraIssue in jiraIssueList)
            {
                IssueRef issueRef = new IssueRef();
                issueRef.key = jiraIssue.JiraKey;
                issueRef.id = jiraIssue.JiraID;

                try
                {
                    workLogs = PullWorkLogs(issueRef, JiraAccount, JiraPassword);
                    foreach (Worklog workLog in workLogs)
                    {
                        JiraWorkLog jiraWorkLog = new JiraWorkLog();
                        jiraWorkLog.Initialize(jiraIssue.JiraKey, workLog);

                        if (!JiraWorkLogDAO.IsExist(jiraWorkLog))
                        {
                            JiraWorkLogDAO.Insert(jiraWorkLog);
                        }
                        else
                        {
                            JiraWorkLogDAO.Update(jiraWorkLog);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to store work log info to local for jira key {jiraIssue.JiraKey}.", ex);
                }

                List<JiraSubTask> subTasks = JiraSubTaskDAO.GetEntitiesByParentJiraKey(jiraIssue.JiraKey);
                foreach (JiraSubTask subTask in subTasks)
                {
                    IssueRef subTaskRef = new IssueRef();
                    subTaskRef.key = subTask.JiraKey;
                    subTaskRef.id = subTask.JiraID;

                    try
                    {
                        workLogs = PullWorkLogs(issueRef, JiraAccount, JiraPassword);
                        foreach (Worklog workLog in workLogs)
                        {
                            JiraWorkLog jiraWorkLog = new JiraWorkLog();
                            jiraWorkLog.Initialize(jiraIssue.JiraKey, workLog);

                            if (!JiraWorkLogDAO.IsExist(jiraWorkLog))
                            {
                                JiraWorkLogDAO.Insert(jiraWorkLog);
                            }
                            else
                            {
                                JiraWorkLogDAO.Update(jiraWorkLog);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to store work log info to local for jira key {subTask.JiraKey}.", ex);
                    }
                }
            }

            return true;
        }

        public int StoreIssueInfoToLocal(JiraIssue issueInfo)
        {
            JiraIssue entity = null;
            int ID = 0;

            if (!IsExistsLocalIssue(issueInfo.JiraKey))
            {
                entity = JiraIssueDAO.Insert(issueInfo);
                ID = entity.ID;
            }
            else
            {
                JiraIssueDAO.Update(issueInfo);
            }

            return ID;
        }

        public List<string> GetUnimportedCases(List<string> caseNos)
        {
            List<string> unimportedCases = new List<string>();

            List<JiraIssue> issues = JiraIssueDAO.GetEntitiesByCaseNo(caseNos);

            foreach (JiraIssue issue in issues)
            {
                caseNos.Remove(issue.CaseNumber);
            }

            unimportedCases.AddRange(caseNos);

            return unimportedCases;
        }
    }
}