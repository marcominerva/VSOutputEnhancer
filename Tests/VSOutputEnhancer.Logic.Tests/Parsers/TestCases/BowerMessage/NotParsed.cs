using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BowerMessage;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BowerMessage
{
    [ExcludeFromCodeCoverage]
    public class NotParsed : TestCaseBase
    {
        public override string Input { get; } = "Some message\r\n";
        public override BowerMessageData ExpectedResult { get; } = null;
    }
}