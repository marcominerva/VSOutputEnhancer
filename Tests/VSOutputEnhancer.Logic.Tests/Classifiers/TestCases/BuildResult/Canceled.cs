using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class Canceled : TestCaseBase
    {
        public override string Input { get; } = "Build has been canceled.\r\n";
        public override ProcessedParsedData ExpectedResult { get; } = new ProcessedParsedData(new Span(0, 26), ClassificationType.BuildResultFailed);
    }
}
