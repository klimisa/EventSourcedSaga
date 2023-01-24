namespace EventSourcedSaga.Barista.Services;

using Eventuous;
using Eventuous.Process;
using Messages;
using Process;

public class BaristaService : ProcessManager<DrinkPreparation, DrinkPreparationState, DrinkPreparationId>
{
    public BaristaService
    (
        IAggregateStore store,
        AggregateFactoryRegistry? factoryRegistry = null,
        StreamNameMap? streamNameMap = null,
        TypeMapper? typeMap = null
    ) : base(store, factoryRegistry, streamNameMap, typeMap)
    {
        OnNew<NewOrder>(
            message => new DrinkPreparationId($"{message.Id}"),
            (drinkPreparationSaga, message) =>
                drinkPreparationSaga.Handle(
                    new State.Initial(),
                    message.ToInput())
        );
        OnExisting<PaymentComplete>(
            message => new DrinkPreparationId($"{message.OrderId}"),
            (drinkPreparationSaga, message) =>
                drinkPreparationSaga.Handle(
                    drinkPreparationSaga.State.State,
                    message.ToInput())
        );
    }
}
