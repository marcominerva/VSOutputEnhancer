using Balakin.VSOutputEnhancer.Logic.Classifiers;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers
{
    public interface ITestCase<TParsedData> where TParsedData : ParsedData
    {
        IParser<TParsedData> CreateParser();
        string Input { get; }
        TParsedData ExpectedResult { get; }
    }
}