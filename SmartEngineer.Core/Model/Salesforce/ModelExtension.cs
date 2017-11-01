using TechTalk.JiraRestClient;

namespace SmartEngineer.Core.Models
{
    public static class ModelExtension
    {
        public static Issue ConvertToIssue(this CaseInfo caseInfo)
        {
            Issue issue = new Issue();

            return issue;
        }

        public static bool IsEqualCase(this JiraIssue jiraIssue, CaseInfo caseInfo)
        {
            bool isEqual = false;

            return isEqual;
        }

        public static bool IsEqualJiraIssue(this CaseInfo caseInfo, JiraIssue jiraIssue)
        {
            bool isEqual = false;

            return isEqual;
        }
    }
}
