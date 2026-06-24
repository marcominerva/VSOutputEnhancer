using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class Rebuild : TestCaseBase
    {
        public override string Input { get; } = "========== Rebuild All: 2 succeeded, 135 failed, 86 skipped ==========\r\n";

        public override BuildResultData ExpectedResult { get; } = new BuildResultData(
            new ParsedValue<int>(2, new Span(24, 1)),
            new ParsedValue<int>(135, new Span(37, 3)),
            new ParsedValue<int>(),
            new ParsedValue<int>(86, new Span(49, 2))
        );
    }
}