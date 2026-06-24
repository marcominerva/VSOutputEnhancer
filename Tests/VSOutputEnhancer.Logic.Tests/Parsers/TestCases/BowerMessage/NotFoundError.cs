using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BowerMessage;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BowerMessage
{
    [ExcludeFromCodeCoverage]
    public class NotFoundError : TestCaseBase
    {
        public override string Input { get; } = "bower bootstrap1#3.3.5       ENOTFOUND Package bootstrap1 not found\r\n";

        public override BowerMessageData ExpectedResult { get; } = new BowerMessageData
        {
            PackageName = new ParsedValue<string>("bootstrap1", new Span(6, 10)),
            PackageVersion = new ParsedValue<string>("3.3.5", new Span(17, 5)),
            Type = new ParsedValue<MessageType>(MessageType.Error, new Span(29, 9)),
            ErrorCode = new ParsedValue<string>("ENOTFOUND", new Span(29, 9)),
            Message = new ParsedValue<string>("Package bootstrap1 not found", new Span(39, 28))
        };
    }
}