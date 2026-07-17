using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BowerMessage;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class BowerMessageClassifier(IParser<BowerMessageData> parser) : ParserBasedSpanClassifier<BowerMessageData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } = new[]
    {
        ContentType.Output
    };

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
        switch (messageType)
        {
            case MessageType.Error:
                return ClassificationType.BowerMessageError;
            default:
                return null;
        }
    }
}