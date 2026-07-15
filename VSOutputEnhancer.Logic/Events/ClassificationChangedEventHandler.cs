using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Logic.Events
{
    [Export(typeof(IEventHandler))]
    public class ClassificationChangedEventHandler : IEventHandler<ClassificationChangedEvent>
    {
        public IEnumerable<string> ContentTypes { get; } =
        [
            ContentType.BuildOutput,
            ContentType.BuildOrderOutput
        ];

        public void Handle(IDispatcher dispatcher, DataContainer data, ClassificationChangedEvent @event)
        {
            var handler = data.Get<EventHandler<ClassificationChangedEventArgs>>(null);
            handler?.Invoke(this, new ClassificationChangedEventArgs(@event.Span));
        }
    }
}
