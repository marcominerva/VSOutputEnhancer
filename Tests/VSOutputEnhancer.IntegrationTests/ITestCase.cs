using System.Collections.Generic;

namespace Balakin.VSOutputEnhancer.IntegrationTests
{
    public interface ITestCase
    {
        string ContentType { get; }
        IReadOnlyList<string> SourceText { get; }
        IReadOnlyList<ClassifiedText> ExpectedResult { get; }
    }
}