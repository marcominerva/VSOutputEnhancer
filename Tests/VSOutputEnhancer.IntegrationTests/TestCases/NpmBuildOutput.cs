using System.Diagnostics.CodeAnalysis;

namespace Balakin.VSOutputEnhancer.IntegrationTests.TestCases
{
    [ExcludeFromCodeCoverage]
    public class NpmBuildOutput : NpmOutputBase
    {
        public override string ContentType { get; } = Logic.ContentType.BuildOutput;
    }
}