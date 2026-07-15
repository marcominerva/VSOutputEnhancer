using System.Collections.Generic;
using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;
using Balakin.VSOutputEnhancer.Logic.Events;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildActionStart
{
    [Export(typeof(IEventHandler))]
    public class BuildFinishedEventHandler : IEventHandler<SpanParsedEvent<BuildResultData>>
    {
        private static readonly string[] Actions = ["Build", "Rebuild All", "Clean", "Publish"];

        public IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        public void Handle(IDispatcher dispatcher, DataContainer data, SpanParsedEvent<BuildResultData> @event)
        {
            foreach (var action in Actions)
            {
                HandleActionFinished(action, dispatcher, data);
            }
        }

        private static void HandleActionFinished(string action, IDispatcher dispatcher, DataContainer data)
        {
            var actionCollection = data.Get<BuildActionCollection>();

            var projects = actionCollection.EnumerateProjects(action);
            foreach (var project in projects)
            {
                var changed = actionCollection.HandleStateChange(action, project, BuildActionState.Success);
                if (changed)
                {
                    actionCollection.PreserveStateForNextClassification(action, project);
                    var span = actionCollection.GetSpan(action, project);
                    dispatcher.Dispatch(new ClassificationChangedEvent(span), data);
                }
            }

            actionCollection.DeleteAll(action);
        }
    }
}
