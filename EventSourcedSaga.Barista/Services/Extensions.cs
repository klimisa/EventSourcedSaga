namespace EventSourcedSaga.Barista.Services;

using Messages;
using Process;

public static class Extensions
{
    public static Input ToInput(this NewOrder message) =>
        new Input.NewOrder(Guid.NewGuid(), message.Name, message.Size, message.Item);

    public static Input ToInput(this PaymentComplete message) =>
        new Input.PaymentComplete(message.CorrelationId);
}
