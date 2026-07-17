using System.Diagnostics.CodeAnalysis;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.DebugTraceMessage
{
    [ExcludeFromCodeCoverage]
    public class UnsupportedMessageType : TestCaseBase
    {
        public override string Input { get; } = "VSOutputEnhancerDemo.vshost.exe Transfer: 0 : Trace warning message\r\n";
        public override ProcessedParsedData ExpectedResult { get; } = null;
    }
}