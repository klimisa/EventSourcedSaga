namespace EventSourcedSaga.Barista.Services;

using Eventuous.Process;
using Process;

public record DrinkPreparationState : ProcessState<DrinkPreparationState>
{
    public State State { get; private init; }

    public DrinkPreparationState()
    {
        On<Received__NewOrder>((state, @event) =>
            state with
            {
                State = DrinkPreparation.Evolve(new State.Initial(), @event)
            });

        On<Received__PaymentComplete>((state, @event) =>
            state with
            {
                State = DrinkPreparation.Evolve(state.State, @event)
            });
    }
}
