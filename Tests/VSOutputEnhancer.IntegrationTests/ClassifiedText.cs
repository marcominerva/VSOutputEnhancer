using System;
using System.Diagnostics.CodeAnalysis;

namespace Balakin.VSOutputEnhancer.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public struct ClassifiedText
    {
        public string ClassificationType { get; }
        public string Text { get; }

        public ClassifiedText(string classificationType, string text)
        {
            ClassificationType = classificationType;
            Text = text;
        }
    }
}