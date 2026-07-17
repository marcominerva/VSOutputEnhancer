using System;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.DebugException;

// TODO: Review accessibility level
public class DebugExceptionData : ParsedData
{
    // TODO: Refactor ParsedData builder to get rid of this constructor
    public DebugExceptionData()
    {
    }

    public DebugExceptionData(ParsedValue<string> exception, ParsedValue<string> assembly)
    {
        Exception = exception;
        Assembly = assembly;
    }

    public ParsedValue<string> Exception { get; private set; }
    public ParsedValue<string> Assembly { get; private set; }
}