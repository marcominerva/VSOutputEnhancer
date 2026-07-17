using System;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;

// TODO: Review accessibility level
public class BuildFileRelatedMessageData : ParsedData
{
    // TODO: Refactor ParsedData builder to get rid of this constructor
    public BuildFileRelatedMessageData()
    {
    }

    public BuildFileRelatedMessageData(
        ParsedValue<int> buildTaskId,
        ParsedValue<MessageType> type,
        ParsedValue<string> code,
        ParsedValue<string> message,
        ParsedValue<string> fullMessage,
        ParsedValue<string> filePath)
    {
        BuildTaskId = buildTaskId;
        Type = type;
        Code = code;
        Message = message;
        FullMessage = fullMessage;
        FilePath = filePath;
    }

    // This properties filled using reflection
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    public ParsedValue<int> BuildTaskId { get; private set; }
    public ParsedValue<MessageType> Type { get; private set; }
    public ParsedValue<string> Code { get; private set; }
    public ParsedValue<string> Message { get; private set; }
    public ParsedValue<string> FullMessage { get; private set; }
    public ParsedValue<string> FilePath { get; private set; }
    // ReSharper restore UnusedAutoPropertyAccessor.Local
}