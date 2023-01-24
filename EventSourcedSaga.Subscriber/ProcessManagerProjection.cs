namespace EventSourcedSaga.Subscriber;

using Eventuous.Subscriptions;
using Eventuous.Subscriptions.Context;

public class ProcessManagerProjection: IEventHandler
{
    public ValueTask<EventHandlingStatus> HandleEvent(IMessageConsumeContext context)
    {
        throw new NotImplementedException();
    }

    public string DiagnosticName => "SagaProjection";
}
