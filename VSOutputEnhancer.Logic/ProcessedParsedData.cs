using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic
{
    public class ProcessedParsedData(Span span, string classificationName)
    {
        public Span Span { get; } = span;
        public string ClassificationName { get; } = classificationName;
    }
}