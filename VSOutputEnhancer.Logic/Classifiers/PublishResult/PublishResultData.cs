using System;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.PublishResult;

public class PublishResultData : ParsedData
{
    // TODO: Refactor ParsedData builder to get rid of this constructor
    public PublishResultData()
    {
    }

    public PublishResultData(ParsedValue<int> succeeded, ParsedValue<int> failed, ParsedValue<int> skipped)
    {
        Succeeded = succeeded;
        Failed = failed;
        Skipped = skipped;
    }

    public ParsedValue<int> Succeeded { get; private set; }
    public ParsedValue<int> Failed { get; private set; }
    public ParsedValue<int> Skipped { get; private set; }
}