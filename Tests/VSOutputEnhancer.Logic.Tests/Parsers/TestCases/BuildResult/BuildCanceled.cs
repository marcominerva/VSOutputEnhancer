using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class BuildCanceled : TestCaseBase
    {
        public override string Input { get; } = "Build has been canceled.\r\n";

        public override BuildResultData ExpectedResult { get; } = BuildResultData.Canceled();
    }
}