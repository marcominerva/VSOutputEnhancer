using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers.NpmResult;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers.TestCases.NpmResult
{
    [ExcludeFromCodeCoverage]
    public abstract class TestCaseBase : ITestCase
    {
        public ISpanClassifier CreateClassifier()
        {
            var parser = new NpmResultParser();
            var classifier = new NpmResultClassifier(parser);
            return classifier;
        }

        public abstract string Input { get; }
        public abstract ProcessedParsedData ExpectedResult { get; }
    }
}