using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.DebugTraceMessage;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.DebugTraceMessage
{
    [ExcludeFromCodeCoverage]
    public class Error : TestCaseBase
    {
        public override string Input { get; } = "VSOutputEnhancerDemo.vshost.exe Information: 10 : Trace information message\r\n";

        public override DebugTraceMessageData ExpectedResult { get; } = new DebugTraceMessageData(
            new ParsedValue<string>("VSOutputEnhancerDemo.vshost.exe", new Span(0, 31)),
            new ParsedValue<TraceEventType>(TraceEventType.Information, new Span(32, 11)),
            new ParsedValue<int>(10, new Span(45, 2)),
            new ParsedValue<string>("Trace information message", new Span(50, 25)),
            new ParsedValue<string>("Information: 10 : Trace information message", new Span(32, 43))
        );
    }
}