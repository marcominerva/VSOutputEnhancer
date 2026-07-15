using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart;
using Balakin.VSOutputEnhancer.Tests.Base;
using FluentAssertions;
using Xunit;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.BuildActionStart
{
    [ExcludeFromCodeCoverage]
    public class BuildActionCollectionTests
    {
        [Fact]
        public void RegisterActionStartIsIdempotentAndDoesNotResetState()
        {
            var collection = new BuildActionCollection();
            var span = "started".ToSnapshotSpan();

            collection.RegisterActionStart(0, 1, span);
            collection.TryRaiseStateForMessage(10, 1, BuildActionState.Error, out _);

            collection.RegisterActionStart(0, 1, span);

            collection.GetState(0).Should().Be(BuildActionState.Error);
        }

        [Fact]
        public void MessageIsAttributedToNearestPrecedingActionStart()
        {
            var collection = new BuildActionCollection();
            collection.RegisterActionStart(0, null, "first".ToSnapshotSpan());
            collection.RegisterActionStart(100, null, "second".ToSnapshotSpan());

            collection.TryRaiseStateForMessage(150, null, BuildActionState.Error, out _).Should().BeTrue();

            collection.GetState(0).Should().Be(BuildActionState.Unknown);
            collection.GetState(100).Should().Be(BuildActionState.Error);
        }

        [Fact]
        public void ParallelMessageIsAttributedByBuildTaskId()
        {
            var collection = new BuildActionCollection();
            collection.RegisterActionStart(0, 1, "task1".ToSnapshotSpan());
            collection.RegisterActionStart(50, 2, "task2".ToSnapshotSpan());

            collection.TryRaiseStateForMessage(200, 1, BuildActionState.Error, out _).Should().BeTrue();

            collection.GetState(0).Should().Be(BuildActionState.Error);
            collection.GetState(50).Should().Be(BuildActionState.Unknown);
        }

        [Fact]
        public void StateOnlyRaisesSeverity()
        {
            var collection = new BuildActionCollection();
            collection.RegisterActionStart(0, null, "started".ToSnapshotSpan());

            collection.TryRaiseStateForMessage(10, null, BuildActionState.Error, out _).Should().BeTrue();
            collection.TryRaiseStateForMessage(10, null, BuildActionState.Warning, out _).Should().BeFalse();

            collection.GetState(0).Should().Be(BuildActionState.Error);
        }

        [Fact]
        public void CompletePendingActionsMarksOnlyUnknownAsSuccess()
        {
            var collection = new BuildActionCollection();
            collection.RegisterActionStart(0, null, "failed".ToSnapshotSpan());
            collection.RegisterActionStart(100, null, "pending".ToSnapshotSpan());
            collection.TryRaiseStateForMessage(10, null, BuildActionState.Error, out _);

            var completed = collection.CompletePendingActions().ToList();

            completed.Should().HaveCount(1);
            collection.GetState(0).Should().Be(BuildActionState.Error);
            collection.GetState(100).Should().Be(BuildActionState.Success);
        }
    }
}
