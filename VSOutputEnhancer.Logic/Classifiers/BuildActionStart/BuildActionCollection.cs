using System.Collections.Generic;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    public class BuildActionCollection
    {
        private sealed class BuildActionEntry
        {
            public int Position { get; set; }

            public int? BuildTaskId { get; set; }

            public SnapshotSpan Span { get; set; }

            public BuildActionState State { get; set; }
        }

        private readonly IDictionary<int, BuildActionEntry> entries = new Dictionary<int, BuildActionEntry>();

        public void RegisterActionStart(int position, int? buildTaskId, SnapshotSpan span)
        {
            if (!entries.TryGetValue(position, out var entry))
            {
                entry = new BuildActionEntry
                {
                    Position = position,
                    State = BuildActionState.Unknown
                };
                entries.Add(position, entry);
            }

            entry.BuildTaskId = buildTaskId;
            entry.Span = span;
        }

        public BuildActionState GetState(int position)
        {
            return entries.TryGetValue(position, out var entry) ? entry.State : BuildActionState.Unknown;
        }

        public bool TryRaiseStateForMessage(int messagePosition, int? buildTaskId, BuildActionState state, out SnapshotSpan span)
        {
            span = default;

            var entry = FindPrecedingEntry(messagePosition, buildTaskId);
            if (entry is null || entry.State >= state)
            {
                return false;
            }

            entry.State = state;
            span = TranslateToCurrentSnapshot(entry.Span);
            return true;
        }

        public IEnumerable<SnapshotSpan> CompletePendingActions()
        {
            var result = new List<SnapshotSpan>();
            foreach (var entry in entries.Values)
            {
                if (entry.State == BuildActionState.Unknown)
                {
                    entry.State = BuildActionState.Success;
                    result.Add(TranslateToCurrentSnapshot(entry.Span));
                }
            }

            return result;
        }

        private BuildActionEntry FindPrecedingEntry(int position, int? buildTaskId)
        {
            BuildActionEntry best = null;
            foreach (var entry in entries.Values)
            {
                if (entry.Position > position)
                {
                    continue;
                }

                if (buildTaskId is not null && entry.BuildTaskId != buildTaskId)
                {
                    continue;
                }

                if (best is null || entry.Position > best.Position)
                {
                    best = entry;
                }
            }

            return best;
        }

        private static SnapshotSpan TranslateToCurrentSnapshot(SnapshotSpan span)
        {
            var currentSnapshot = span.Snapshot.TextBuffer.CurrentSnapshot;
            return span.Snapshot == currentSnapshot
                ? span
                : span.TranslateTo(currentSnapshot, SpanTrackingMode.EdgeExclusive);
        }
    }
}
