using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public class Build : TestCaseBase
    {
        public override string Input { get; } = "1>------ Build started: Project: VSOutputEnhancer, Configuration: Debug Any CPU ------\r\n";

        public override ProcessedParsedData ExpectedResult { get; } = new ProcessedParsedData(new Span(0, 88), ClassificationType.BuildProjectHeader);
    }
}
