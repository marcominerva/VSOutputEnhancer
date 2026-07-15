using System.Diagnostics.CodeAnalysis;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public class NotClassified : TestCaseBase
    {
        public override string Input { get; } = "------ Build started: Project: VSOutputEnhancer, Configuration: Debug Any CPU ------\r\n";

        public override ProcessedParsedData ExpectedResult { get; } = null;
    }
}
