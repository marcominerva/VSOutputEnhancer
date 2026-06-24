using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class FailFastBuildCanceled : TestCaseBase
    {
        public override string Input { get; } = "Fail Fast: Build cancelled because project \"AtiPortal.BusinessLayer\" failed at 10:07:16.\r\n";

        public override BuildResultData ExpectedResult { get; } = BuildResultData.Canceled();
    }
}