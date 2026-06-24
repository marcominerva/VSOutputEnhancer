using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.NpmMessage
{
    [Export(typeof(ISpanClassifier))]
    [method: ImportingConstructor]
    public class NpmMessageClassifier(IParser<NpmMessageData> parser) : ParserBasedSpanClassifier<NpmMessageData>(parser)
    {
        public override IEnumerable<string> ContentTypes { get; } = new[]
        {
            ContentType.Output,
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        };

        protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, NpmMessageData parsedData)
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
                case MessageType.Warning:
                    return ClassificationType.NpmMessageWarning;
                case MessageType.Error:
                    return ClassificationType.NpmMessageError;
                default:
                    return null;
            }
        }
    }
}