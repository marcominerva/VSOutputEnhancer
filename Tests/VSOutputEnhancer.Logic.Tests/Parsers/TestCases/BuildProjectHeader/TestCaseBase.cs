using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public abstract class TestCaseBase : ITestCase<BuildProjectHeaderData>
    {
        public abstract string Input { get; }

        public abstract BuildProjectHeaderData ExpectedResult { get; }

        public IParser<BuildProjectHeaderData> CreateParser() => new BuildProjectHeaderParser();
    }
}
