namespace EventSourcedSaga.Barista.Saga;

public record Input
{
    public record NewOrder(Guid CorrelationId, string Name, string Size, string Item) : Input;

    public record PaymentComplete(Guid CorrelationId) : Input;
}
