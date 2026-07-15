using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.DebugException
{
    [Export(typeof(ISpanClassifier))]
    [method: ImportingConstructor]
    public class DebugExceptionClassifier(IParser<DebugExceptionData> parser) : ParserBasedSpanClassifier<DebugExceptionData>(parser)
    {
        public override IEnumerable<string> ContentTypes { get; } = new[]
        {
            ContentType.DebugOutput,
        };

        protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, DebugExceptionData parsedData, DataContainer data)
        {
            yield return new ProcessedParsedData(span, ClassificationType.DebugException);
        }
    }
}