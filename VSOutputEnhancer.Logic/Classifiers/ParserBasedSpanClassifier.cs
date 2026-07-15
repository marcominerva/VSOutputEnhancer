using System.Collections.Generic;
using Balakin.VSOutputEnhancer.Logic.Events;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers
{
    public abstract class ParserBasedSpanClassifier<TParsedData>(IParser<TParsedData> parser) : ISpanClassifier
        where TParsedData : ParsedData
    {
        private static readonly IEnumerable<ProcessedParsedData> Empty = new ProcessedParsedData[0];

        private readonly IParser<TParsedData> _parser = parser;

        public abstract IEnumerable<string> ContentTypes { get; }

        protected abstract IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, TParsedData parsedData, DataContainer data);

        public IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, IDispatcher dispatcher, DataContainer data)
        {
            if (!_parser.TryParse(span, out var parsedData))
            {
                return Empty;
            }

            dispatcher.Dispatch(new SpanParsedEvent<TParsedData>(span, parsedData), data);

            return Classify(span, parsedData, data);
        }
    }
}