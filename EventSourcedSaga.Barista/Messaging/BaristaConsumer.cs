namespace EventSourcedSaga.Barista.Messaging;

using MassTransit;
using Messages;

public class BaristaConsumer :
    IConsumer<NewOrder>,
    IConsumer<PrepareDrink>,
    IConsumer<PaymentComplete>
{
    public Task Consume(ConsumeContext<NewOrder> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<PrepareDrink> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<PaymentComplete> context)
    {
        throw new NotImplementedException();
    }
}
