using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    [Export(typeof(ISpanClassifier))]
    [method: ImportingConstructor]
    public class BuildActionStartClassifier(IParser<BuildActionStartData> parser) : ParserBasedSpanClassifier<BuildActionStartData>(parser)
    {
        public override IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        protected override IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, BuildActionStartData parsedData, DataContainer data)
        {
            var buildTaskId = parsedData.BuildTaskId.ToNullable();
            var actionCollection = data.Get<BuildActionCollection>();

            var position = span.Span.Start;
            actionCollection.RegisterActionStart(position, buildTaskId, span);
            var state = actionCollection.GetState(position);
            var classificationType = state switch
            {
                BuildActionState.Success => ClassificationType.BuildActionStartedSuccess,
                BuildActionState.Warning => ClassificationType.BuildActionStartedWarning,
                BuildActionState.Error => ClassificationType.BuildActionStartedError,
                _ => ClassificationType.BuildActionStarted
            };

            yield return new ProcessedParsedData(parsedData.FullMessage.Span, classificationType);
        }
    }
}
