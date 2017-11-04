using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Framework.Utils
{
    public class CommonUtil
    {
        public static string GetJiraTargetStatus(string jiraIssueType, string jiraStatus, string caseOwner, string caseStaus)
        {
            string nextJiraStatus = "";

            if ("Bug".Equals(jiraIssueType, StringComparison.InvariantCultureIgnoreCase))
            {
                if ("Pending".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    || "Open".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    || "In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                {
                    nextJiraStatus = "Dev In Progress";
                }
            }

            if ("Case".Equals(jiraIssueType, StringComparison.InvariantCultureIgnoreCase))
            {
                if ("CLOSED".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                       || "PM Assigned".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                       || "Ideas (Closed)".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                       || "Closed - Knowledge".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase)
                       || "SPAM Closed".Equals(caseStaus, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!"Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        nextJiraStatus = "Closed";
                    }
                }
                else {

                    if ("Engineering".Equals(caseOwner, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (("Eng New".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                            || "Eng QA".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                            || "Qa In Progress".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)
                            || "EngQA".Equals(caseStaus, System.StringComparison.InvariantCultureIgnoreCase)))
                        {
                            if (!"In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                            {
                                nextJiraStatus = "In Progress";
                            }
                        }
                    }
                    else
                    {
                        if (!"Pending".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                        {
                            nextJiraStatus = "Pending";
                        }
                    }
                }
            }

            return nextJiraStatus;
        }

        public static bool TryParseBool(dynamic value, out bool result)
        {
            bool isParseBool = "Yes".Equals(value, StringComparison.OrdinalIgnoreCase)
                                || "True".Equals(value, StringComparison.OrdinalIgnoreCase)
                                || "No".Equals(value, StringComparison.OrdinalIgnoreCase)
                                || "False".Equals(value, StringComparison.OrdinalIgnoreCase);

            if (isParseBool)
            {
                result = IsTrue(value);
            }
            else
            {
                result = false;
            }

            return isParseBool;
        }

        public static bool IsTrue(dynamic value)
        {
            return "Yes".Equals(value, StringComparison.OrdinalIgnoreCase) || "True".Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFalse(dynamic value)
        {
            return "No".Equals(value, StringComparison.OrdinalIgnoreCase) || "False".Equals(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
