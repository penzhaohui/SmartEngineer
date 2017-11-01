namespace SmartEngineer.Core.Model
{
    public enum JiraSubTaskType
    {
        ReviewAndRecreateByQA = 1,
        ReviewAndRecreateByDev = 2,
        ResearchRootCauseByDev = 4,
        CodeFixByDev = 8,
        WriteTestCaseByQA = 16,
        ExecuteTestCaseByQA = 32,
        WriteReleaseNotesByDev = 64,
        ReviewReleaseNotesByQA = 128
    }
}
