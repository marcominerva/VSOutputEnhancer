using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Events
{
    public class ClassificationChangedEvent(SnapshotSpan span) : IEvent
    {
        public SnapshotSpan Span { get; } = span;
    }
}
