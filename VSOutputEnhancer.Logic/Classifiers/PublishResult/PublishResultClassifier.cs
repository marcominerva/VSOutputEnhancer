using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.PublishResult
{
    [Export(typeof(ISpanClassifier))]
    [method: ImportingConstructor]
    public class PublishResultClassifier(IParser<PublishResultData> parser) : ParserBasedSpanClassifier<PublishResultData>(parser)
    {
        public override IEnumerable<string> ContentTypes { get; } = new[]
        {
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        };

        protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, PublishResultData parsedData)
        {
            if (parsedData.Failed == 0)
            {
                yield return new ProcessedParsedData(span, ClassificationType.PublishResultSucceeded);
            }
            else
            {
                yield return new ProcessedParsedData(span, ClassificationType.PublishResultFailed);
            }
        }
    }
}