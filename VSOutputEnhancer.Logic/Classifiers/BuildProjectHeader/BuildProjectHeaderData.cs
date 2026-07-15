namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

public class BuildProjectHeaderData : ParsedData
{
    // TODO: Refactor ParsedData builder to get rid of this constructor
    public BuildProjectHeaderData()
    {
    }

    public BuildProjectHeaderData(ParsedValue<int> buildTaskId, ParsedValue<string> fullMessage)
    {
        BuildTaskId = buildTaskId;
        FullMessage = fullMessage;
    }

    public ParsedValue<int> BuildTaskId { get; private set; }

    public ParsedValue<string> FullMessage { get; private set; }
}
