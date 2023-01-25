namespace EventSourcedSaga.Barista.Process;

public record Output
{
    public record DrinkReady(Guid CorrelationId, string Drink, string Name) : Output;

    public record PrepareDrink(Guid CorrelationId, string Drink, string Name) : Output;

    public record Complete();
}
