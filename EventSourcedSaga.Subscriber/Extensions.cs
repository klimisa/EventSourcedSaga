namespace EventSourcedSaga.Subscriber;

using Eventuous.EventStore.Subscriptions;
using Eventuous.Projections.MongoDB;

public static class Extensions
{
    public static void AddEventuous(this IServiceCollection services)
    {
        services.AddEventStoreClient("esdb://localhost:2113?tls=false");
        services.AddSingleton(Mongo.ConfigureMongo());
        services.AddCheckpointStore<MongoCheckpointStore>();
        services.AddSubscription<AllStreamSubscription, AllStreamSubscriptionOptions>(
            "process-manager", builder => builder.AddEventHandler<ProcessManagerProjection>()
        );
    }
}
