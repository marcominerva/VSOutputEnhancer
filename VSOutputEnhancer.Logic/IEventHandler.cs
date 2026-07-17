namespace Balakin.VSOutputEnhancer.Logic;

public interface IEventHandler
{
    IEnumerable<string> ContentTypes { get; }
}

public interface IEventHandler<in TEvent> : IEventHandler
    where TEvent : IEvent
{
    void Handle(TEvent @event);
}