using System.ComponentModel.Composition;
using System.Diagnostics;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.DebugTraceMessage;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class DebugTraceMessageClassifier(IParser<DebugTraceMessageData> parser) : ParserBasedSpanClassifier<DebugTraceMessageData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } =
    [
        ContentType.DebugOutput,
    ];

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
        return eventType switch
        {
            TraceEventType.Critical or TraceEventType.Error => ClassificationType.DebugTraceError,
            TraceEventType.Warning => ClassificationType.DebugTraceWarning,
            TraceEventType.Information => ClassificationType.DebugTraceInformation,
            _ => null,
        };
    }
}