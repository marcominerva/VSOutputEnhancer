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
            var action = parsedData.Action.Value;
            var projectName = parsedData.ProjectName.Value;
            var buildTaskId = parsedData.BuildTaskId.ToNullable();
            var actionCollection = data.Get<BuildActionCollection>();

            actionCollection.HandleActionStart(action, projectName, buildTaskId, span);
            var state = actionCollection.GetState(action, projectName);
            var classificationType = state switch
            {
                BuildActionState.Success => ClassificationType.BuildActionStartedSuccess,
                BuildActionState.Warning => ClassificationType.BuildActionStartedWarning,
                BuildActionState.Error => ClassificationType.BuildActionStartedError,
                _ => null
            };

            if (classificationType is not null)
            {
                yield return new ProcessedParsedData(parsedData.FullMessage.Span, classificationType);
            }
        }
    }
}
