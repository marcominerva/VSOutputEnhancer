using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.BuildProjectHeader
{
    [ExcludeFromCodeCoverage]
    public abstract class TestCaseBase : ITestCase
    {
        public abstract string Input { get; }

        public abstract ProcessedParsedData ExpectedResult { get; }

        public ISpanClassifier CreateClassifier() => new BuildProjectHeaderClassifier(new BuildProjectHeaderParser());
    }
}
