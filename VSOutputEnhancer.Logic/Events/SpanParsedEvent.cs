using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Events
{
    public class SpanParsedEvent<TParsedData>(SnapshotSpan span, TParsedData parsedData) : IEvent
    {
        public SnapshotSpan Span { get; } = span;

        public TParsedData ParsedData { get; } = parsedData;
    }
}