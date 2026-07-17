using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.NpmResult;

[Export(typeof(ISpanClassifier))]
[method: ImportingConstructor]
public class NpmResultClassifier(IParser<NpmResultData> parser) : ParserBasedSpanClassifier<NpmResultData>(parser)
{
    public override IEnumerable<string> ContentTypes { get; } =
    [
        ContentType.Output,
        ContentType.BuildOutput,
        ContentType.BuildOrderOutput
    ];

    protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, NpmResultData parsedData)
    {
        if (parsedData.ExitCode == 0)
        {
            yield return new ProcessedParsedData(span, ClassificationType.NpmResultSucceeded);
        }
        else
        {
            yield return new ProcessedParsedData(span, ClassificationType.NpmResultFailed);
        }
    }
}