namespace EventSourcedSaga.Barista.Saga;

using Infrastructure.Saga;
using Services;
using Eventuous;

public class DrinkPreparationSaga : Aggregate<DrinkPreparationState>
{
    public static State Evolve(State state, Event message) =>
        (state, message) switch
        {
            (Saga.State.Initial, Event.Received<Input>(Input.NewOrder m)) =>
                new State.PreparingDrink(
                    $"{m.Size}, {m.Name}",
                    m.Name
                ),
            (Saga.State.PreparingDrink, Event.Received<Input>(Input.PaymentComplete m)) =>
                new State.Completed(),
            _ => state
        };

    public void Handle(State state, Input message)
    {
        switch (state, message)
        {
            case (Saga.State.Initial, Input.NewOrder m):
                var drink = $"{m.Size} {m.Item}";
                Console.WriteLine($"{drink} for {m.Name}, got it!");
                Apply(new Received__NewOrder(m));
                Apply(new Sent__PrepareDrink(
                        new Output.PrepareDrink(
                            m.CorrelationId,
                            drink,
                            m.Name
                        )
                    )
                );
                break;
            case (State.PreparingDrink s, Input.PaymentComplete m):
                Console.WriteLine($"Payment Complete for '{s.Name}' got it!");
                Apply(new Received__PaymentComplete(m));
                Apply(new Published__DrinkReady(
                        new Output.DrinkReady(
                            m.CorrelationId,
                            s.Drink,
                            s.Name
                        )
                    )
                );
                Apply(new Command.Complete());
                break;
            default: throw new Exception($"%A{message} can not be handled by %A{state}");
        }
    }
}
