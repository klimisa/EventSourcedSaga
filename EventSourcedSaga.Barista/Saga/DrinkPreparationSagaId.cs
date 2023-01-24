namespace EventSourcedSaga.Barista.Saga;

public record DrinkPreparationSagaId: Eventuous.AggregateId
{
    public DrinkPreparationSagaId(string value) : base(value)
    {
    }
}
