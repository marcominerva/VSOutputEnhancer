using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildResult
{
    [ExcludeFromCodeCoverage]
    public class Build : TestCaseBase
    {
        public override string Input { get; } = "========== Build: 302 succeeded, 41 failed, 16 up-to-date, 5 skipped ==========\r\n";

        public override BuildResultData ExpectedResult { get; } = new BuildResultData(
            new ParsedValue<int>(302, new Span(18, 3)),
            new ParsedValue<int>(41, new Span(33, 2)),
            new ParsedValue<int>(16, new Span(44, 2)),
            new ParsedValue<int>(5, new Span(59, 1))
        );
    }
}