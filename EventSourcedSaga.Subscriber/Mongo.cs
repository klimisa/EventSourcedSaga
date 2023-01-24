namespace EventSourcedSaga.Subscriber;

using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;

public static class Mongo
{
    public static IMongoDatabase ConfigureMongo()
    {
        var settings = MongoClientSettings.FromConnectionString("mongodb://root:BNYpXiaRK7qnL3hmY5pQ@localhost:27017");
        settings.ClusterConfigurator = cb => cb.Subscribe(new DiagnosticsActivityEventSubscriber());
        return new MongoClient(settings).GetDatabase("stock-markets");
    }
}
