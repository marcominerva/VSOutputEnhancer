using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public class RebuildAll : TestCaseBase
    {
        public override string Input { get; } = "1>------ Rebuild All started: Project: VSOutputEnhancer, Configuration: Debug Any CPU ------\r\n";

        public override BuildProjectHeaderData ExpectedResult { get; } = new BuildProjectHeaderData(
            new ParsedValue<int>(1, new Span(0, 1)),
            new ParsedValue<string>("Rebuild All started: Project: VSOutputEnhancer, Configuration: Debug Any CPU", new Span(9, 76))
        );
    }
}
