using System.Collections.Generic;
using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;
using Balakin.VSOutputEnhancer.Logic.Events;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    [Export(typeof(IEventHandler))]
    public class BuildMessageEventHandler : IEventHandler<SpanParsedEvent<BuildFileRelatedMessageData>>
    {
        public IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        public void Handle(IDispatcher dispatcher, DataContainer data, SpanParsedEvent<BuildFileRelatedMessageData> @event)
        {
            var newState = Convert(@event.ParsedData.Type.Value);
            if (newState == BuildActionState.Unknown)
            {
                return;
            }

            var actionCollection = data.Get<BuildActionCollection>();
            var buildTaskId = @event.ParsedData.BuildTaskId.ToNullable();
            var messagePosition = @event.Span.Span.Start;

            if (actionCollection.TryRaiseStateForMessage(messagePosition, buildTaskId, newState, out var span))
            {
                dispatcher.Dispatch(new ClassificationChangedEvent(span), data);
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
