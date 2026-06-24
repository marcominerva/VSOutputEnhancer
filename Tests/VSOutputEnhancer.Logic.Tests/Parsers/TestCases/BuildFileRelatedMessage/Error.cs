using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildFileRelatedMessage
{
    [ExcludeFromCodeCoverage]
    public class Error : TestCaseBase
    {
        public override string Input { get; } = "Parsers\\BuildFileRelatedMessageParserTests.cs(95,50): error CS1003: Syntax error, ',' expected [UnitTests.csproj]\r\n";

        public override BuildFileRelatedMessageData ExpectedResult { get; } = new BuildFileRelatedMessageData(
            new ParsedValue<int>(),
            new ParsedValue<MessageType>(MessageType.Error, new Span(54, 5)),
            new ParsedValue<string>("CS1003", new Span(60, 6)),
            new ParsedValue<string>("Syntax error, ',' expected [UnitTests.csproj]", new Span(68, 45)),
            new ParsedValue<string>("error CS1003: Syntax error, ',' expected [UnitTests.csproj]", new Span(54, 59)),
            new ParsedValue<string>("Parsers\\BuildFileRelatedMessageParserTests.cs", new Span(0, 45))
        );
    }
}