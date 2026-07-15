using System.Diagnostics.CodeAnalysis;
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
        public void HandleActionStartResetsPreviousState()
        {
            var collection = new BuildActionCollection();
            var firstSpan = "first".ToSnapshotSpan();
            var firstSpanFromNewSnapshot = "first".ToSnapshotSpan();
            var secondSpan = "second".ToSnapshotSpan();

            collection.HandleActionStart("Build", "ConsoleApp2", 1, firstSpan);
            collection.HandleStateChange("Build", "ConsoleApp2", BuildActionState.Error);
            collection.PreserveStateForNextClassification("Build", "ConsoleApp2");
            collection.HandleActionStart("Build", "ConsoleApp2", 1, firstSpanFromNewSnapshot);

            collection.GetState("Build", "ConsoleApp2").Should().Be(BuildActionState.Error);

            collection.HandleActionStart("Build", "ConsoleApp2", 1, firstSpanFromNewSnapshot);

            collection.GetState("Build", "ConsoleApp2").Should().Be(BuildActionState.Unknown);

            collection.HandleStateChange("Build", "ConsoleApp2", BuildActionState.Error);
            collection.HandleActionStart("Build", "ConsoleApp2", 1, secondSpan);

            collection.GetState("Build", "ConsoleApp2").Should().Be(BuildActionState.Unknown);
        }
    }
}
