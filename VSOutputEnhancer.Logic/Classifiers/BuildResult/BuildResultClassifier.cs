using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class BuildResultClassifier(IParser<BuildResultData> parser) : ParserBasedSpanClassifier<BuildResultData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } =
    [
        ContentType.BuildOutput,
        ContentType.BuildOrderOutput
    ];

    protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, BuildResultData parsedData)
    {
        var classificationType = parsedData.Outcome switch
        {
            BuildOutcome.Failed => ClassificationType.BuildResultFailed,
            _ => ClassificationType.BuildResultSucceeded
        };

        yield return new ProcessedParsedData(span, classificationType);
    }
}