using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage
{
    [Export(typeof(ISpanClassifier))]
    [method: ImportingConstructor]
    public class BuildFileRelatedMessageClassifier(IParser<BuildFileRelatedMessageData> parser) : ParserBasedSpanClassifier<BuildFileRelatedMessageData>(parser)
    {
        public override IEnumerable<string> ContentTypes { get; } = new[]
        {
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        };

        protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, BuildFileRelatedMessageData parsedData, DataContainer data)
        {
            var messageSpan = parsedData.FullMessage.Span;
            if (parsedData.Type == MessageType.Warning)
            {
                yield return new ProcessedParsedData(messageSpan, ClassificationType.BuildMessageWarning);
            }
            else if (parsedData.Type == MessageType.Error)
            {
                yield return new ProcessedParsedData(messageSpan, ClassificationType.BuildMessageError);
            }
        }
    }
}