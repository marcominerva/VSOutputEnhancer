using System.Collections.Generic;
using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;
using Balakin.VSOutputEnhancer.Logic.Events;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    [Export(typeof(IEventHandler))]
    public class BuildFinishedEventHandler : IEventHandler<SpanParsedEvent<BuildResultData>>
    {
        public IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        public void Handle(IDispatcher dispatcher, DataContainer data, SpanParsedEvent<BuildResultData> @event)
        {
            var actionCollection = data.Get<BuildActionCollection>();

            foreach (var span in actionCollection.CompletePendingActions())
            {
                dispatcher.Dispatch(new ClassificationChangedEvent(span), data);
            }
        }
    }
}
