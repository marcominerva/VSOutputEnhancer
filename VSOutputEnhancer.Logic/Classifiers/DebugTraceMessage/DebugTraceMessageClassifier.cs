using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.DebugTraceMessage;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class DebugTraceMessageClassifier(IParser<DebugTraceMessageData> parser) : ParserBasedSpanClassifier<DebugTraceMessageData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } = new[]
    {
        ContentType.DebugOutput,
    };

    protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, DebugTraceMessageData parsedData)
    {
        var classificationType = GetClassificationType(parsedData.Type);
        if (string.IsNullOrEmpty(classificationType))
        {
            yield break;
        }

        var resultSpan = parsedData.PrettyMessage.Span;
        var snapshotSpan = new SnapshotSpan(span.Snapshot, resultSpan);
        yield return new ProcessedParsedData(snapshotSpan, classificationType);
    }

    private string GetClassificationType(TraceEventType eventType)
    {
        switch (eventType)
        {
            case TraceEventType.Critical:
            case TraceEventType.Error:
                return ClassificationType.DebugTraceError;
            case TraceEventType.Warning:
                return ClassificationType.DebugTraceWarning;
            case TraceEventType.Information:
                return ClassificationType.DebugTraceInformation;
            default:
                return null;
        }
    }
}