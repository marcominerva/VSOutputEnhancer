using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.DebugException;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.DebugException
{
    [ExcludeFromCodeCoverage]
    public class FirstChanceException : TestCaseBase
    {
        public override string Input { get; } = "A first chance exception of type 'System.Exception' occurred in ConsoleDemo.exe\r\n";

        public override DebugExceptionData ExpectedResult { get; } = new DebugExceptionData(
            new ParsedValue<string>("System.Exception", new Span(34, 16)),
            new ParsedValue<string>("ConsoleDemo.exe", new Span(64, 15))
        );
    }
}