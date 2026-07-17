namespace Balakin.VSOutputEnhancer.Logic.Events;

public class SpanParsedEvent<TParsedData>(TParsedData parsedData) : IEvent
{
    public TParsedData ParsedData { get; } = parsedData;
}