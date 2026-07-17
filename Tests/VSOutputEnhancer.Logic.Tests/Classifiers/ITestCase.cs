namespace Balakin.VSOutputEnhancer.Logic.Tests.Classifiers
{
    public interface ITestCase
    {
        ISpanClassifier CreateClassifier();
        string Input { get; }
        ProcessedParsedData ExpectedResult { get; }
    }
}