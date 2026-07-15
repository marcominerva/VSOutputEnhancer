using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public class NotParsed : TestCaseBase
    {
        public override string Input { get; } = "------ Build started: Project: VSOutputEnhancer, Configuration: Debug Any CPU ------\r\n";

        public override BuildProjectHeaderData ExpectedResult { get; } = null;
    }
}
