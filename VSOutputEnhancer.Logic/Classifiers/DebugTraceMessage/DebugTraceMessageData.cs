using System.Diagnostics;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.DebugTraceMessage;

public class DebugTraceMessageData : ParsedData
{
    // TODO: Refactor ParsedData builder to get rid of this constructor
    public DebugTraceMessageData()
    {
    }

    public DebugTraceMessageData(ParsedValue<string> source, ParsedValue<TraceEventType> type, ParsedValue<int> id, ParsedValue<string> message, ParsedValue<string> prettyMessage)
    {
        Source = source;
        Type = type;
        Id = id;
        Message = message;
        PrettyMessage = prettyMessage;
    }

    // This properties filled using reflection
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    public ParsedValue<string> Source { get; private set; }
    public ParsedValue<TraceEventType> Type { get; private set; }
    public ParsedValue<int> Id { get; private set; }
    public ParsedValue<string> Message { get; private set; }
    public ParsedValue<string> PrettyMessage { get; private set; }
    // ReSharper restore UnusedAutoPropertyAccessor.Local
}