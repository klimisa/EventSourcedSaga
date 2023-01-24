namespace EventSourcedSaga.Barista.Services;

using Eventuous;
using Saga;
using Messages;

public class BaristaService : ApplicationService<DrinkPreparationSaga, DrinkPreparationState, DrinkPreparationSagaId>
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
            message => new DrinkPreparationSagaId($"{message.Id}"),
            (drinkPreparationSaga, message) =>
                drinkPreparationSaga.Handle(
                    new State.Initial(),
                    message.ToInput())
        );
        OnExisting<PaymentComplete>(
            message => new DrinkPreparationSagaId($"{message.OrderId}"),
            (drinkPreparationSaga, message) =>
                drinkPreparationSaga.Handle(
                    drinkPreparationSaga.State.State,
                    message.ToInput())
        );
    }
}
