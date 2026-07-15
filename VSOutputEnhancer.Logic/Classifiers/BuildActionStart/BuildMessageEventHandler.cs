using System.Collections.Generic;
using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;
using Balakin.VSOutputEnhancer.Logic.Events;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    [Export(typeof(IEventHandler))]
    public class BuildMessageEventHandler : IEventHandler<SpanParsedEvent<BuildFileRelatedMessageData>>
    {
        private static readonly string[] BuildActions = ["Build", "Rebuild All", "Clean"];

        public IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        public void Handle(IDispatcher dispatcher, DataContainer data, SpanParsedEvent<BuildFileRelatedMessageData> @event)
        {
            var actionCollection = data.Get<BuildActionCollection>();

            var newState = Convert(@event.ParsedData.Type.Value);
            var buildTaskId = @event.ParsedData.BuildTaskId.ToNullable();

            foreach (var action in BuildActions)
            {
                var projectName = actionCollection.GetLatestProject(action, buildTaskId);
                if (string.IsNullOrEmpty(projectName))
                {
                    continue;
                }

                var changed = actionCollection.HandleStateChange(action, projectName, newState);
                if (changed)
                {
                    actionCollection.PreserveStateForNextClassification(action, projectName);
                    var span = actionCollection.GetSpan(action, projectName);
                    dispatcher.Dispatch(new ClassificationChangedEvent(span), data);
                }

                return;
            }
        }

        private static BuildActionState Convert(MessageType messageType)
        {
            return messageType switch
            {
                MessageType.Warning => BuildActionState.Warning,
                MessageType.Error => BuildActionState.Error,
                _ => BuildActionState.Unknown
            };
        }
    }
}
