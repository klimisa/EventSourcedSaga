namespace EventSourcedSaga.Cashier.Messaging;

using MassTransit;
using Messages;

public class CashierConsumer :
    IConsumer<NewOrder>,
    IConsumer<SubmitPayment>
{
    public Task Consume(ConsumeContext<NewOrder> context)
    {
        throw new NotImplementedException();
    }

    public Task Consume(ConsumeContext<SubmitPayment> context)
    {
        throw new NotImplementedException();
    }
}