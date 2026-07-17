using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class FailFastBuildCanceled : TestCaseBase
    {
        public override string Input { get; } = "Fail Fast: Build cancelled because project \"WebApi\" failed at 10:07:16.\r\n";

        public override ProcessedParsedData ExpectedResult { get; } = new ProcessedParsedData(new Span(0, 73), ClassificationType.BuildResultFailed);
    }
}
