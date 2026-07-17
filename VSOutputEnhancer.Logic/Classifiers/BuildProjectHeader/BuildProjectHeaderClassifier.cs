using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class BuildProjectHeaderClassifier(IParser<BuildProjectHeaderData> parser) : ParserBasedSpanClassifier<BuildProjectHeaderData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } =
    [
        ContentType.BuildOutput,
        ContentType.BuildOrderOutput
    ];

    protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, BuildProjectHeaderData parsedData)
    {
        yield return new ProcessedParsedData(span, ClassificationType.BuildProjectHeader);
    }
}
