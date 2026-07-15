namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    public class BuildActionStartData : ParsedData
    {
        public BuildActionStartData()
        {
        }

        public BuildActionStartData(
            ParsedValue<int> buildTaskId,
            ParsedValue<string> projectName,
            ParsedValue<string> action,
            ParsedValue<string> fullMessage)
        {
            BuildTaskId = buildTaskId;
            ProjectName = projectName;
            Action = action;
            FullMessage = fullMessage;
        }

        public ParsedValue<int> BuildTaskId { get; private set; } = new();

        public ParsedValue<string> ProjectName { get; private set; } = new();

        public ParsedValue<string> Action { get; private set; } = new();

        public ParsedValue<string> FullMessage { get; private set; } = new();
    }
}
