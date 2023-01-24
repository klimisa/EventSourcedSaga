namespace EventSourcedSaga.Barista.Services;

using Eventuous;
using Saga;

public record DrinkPreparationState : State<DrinkPreparationState>
{
    public State State { get; init; }

    public DrinkPreparationState()
    {
        On<Received__NewOrder>((state, @event) =>
            state with
            {
                State = DrinkPreparationSaga.Evolve(new State.Initial(), @event)
            });

        On<Received__PaymentComplete>((state, @event) =>
            state with
            {
                State = DrinkPreparationSaga.Evolve(state.State, @event)
            });
    }
}
