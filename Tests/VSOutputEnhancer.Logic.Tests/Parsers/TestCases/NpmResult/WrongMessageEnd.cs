using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.NpmResult;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.NpmResult
{
    [ExcludeFromCodeCoverage]
    public class WrongMessageEnd : TestCaseBase
    {
        public override string Input { get; } = "====npm command completed with exit code 1823----\r\n";
        public override NpmResultData ExpectedResult { get; } =null;
    }
}