namespace EventSourcedSaga.Barista.Messaging;

using Eventuous;
using MassTransit;
using Messages;
using Services;

public class BaristaConsumer :
    IConsumer<NewOrder>,
    IConsumer<PrepareDrink>,
    IConsumer<PaymentComplete>
{
    private readonly BaristaService service;

    public BaristaConsumer(BaristaService service)
    {
        this.service = service;
    }

    public Task Consume(ConsumeContext<NewOrder> context)
    {
        service.Handle(context.Message, CancellationToken.None);
        return Task.CompletedTask;
    }

    public Task Consume(ConsumeContext<PrepareDrink> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<PaymentComplete> context)
    {
        service.Handle(context.Message, CancellationToken.None);
        return Task.CompletedTask;
    }
}
