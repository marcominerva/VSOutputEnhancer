using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildFileRelatedMessage
{
    [ExcludeFromCodeCoverage]
    public class FatalError : TestCaseBase
    {
        public override string Input { get; } = "1>c:\\source\\Animation.h(15): fatal error C1083: Cannot open include file: 'IDynamicComponent.h': No such file or directory (compiling source file Source\\BehaviorBullet.c)\r\n";

        public override BuildFileRelatedMessageData ExpectedResult { get; } = new BuildFileRelatedMessageData(
            new ParsedValue<int>(1, new Span(0, 1)),
            new ParsedValue<MessageType>(MessageType.Error, new Span(29, 11)),
            new ParsedValue<string>("C1083", new Span(41, 5)),
            new ParsedValue<string>("Cannot open include file: 'IDynamicComponent.h': No such file or directory (compiling source file Source\\BehaviorBullet.c)", new Span(48, 122)),
            new ParsedValue<string>("fatal error C1083: Cannot open include file: 'IDynamicComponent.h': No such file or directory (compiling source file Source\\BehaviorBullet.c)", new Span(29, 141)),
            new ParsedValue<string>("c:\\source\\Animation.h", new Span(2, 21))
        );
    }
}