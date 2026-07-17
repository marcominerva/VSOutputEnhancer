using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BowerMessage;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class BowerMessageClassifier(IParser<BowerMessageData> parser) : ParserBasedSpanClassifier<BowerMessageData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } =
    [
        ContentType.Output
    ];

    protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, BowerMessageData parsedData)
    {
        var classificationType = GetClassificationType(parsedData.Type);
        if (string.IsNullOrEmpty(classificationType))
        {
            yield break;
        }

        yield return new ProcessedParsedData(parsedData.Message.Span, classificationType);
    }

    private string GetClassificationType(MessageType messageType)
    {
        return messageType switch
        {
            MessageType.Error => ClassificationType.BowerMessageError,
            _ => null,
        };
    }
}