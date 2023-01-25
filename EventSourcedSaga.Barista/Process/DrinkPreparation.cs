namespace EventSourcedSaga.Barista.Process;

using Services;
using EventSourcedSaga.Infrastructure.Process;
using Eventuous.Process;

public class DrinkPreparation : Process<DrinkPreparationState>
{
    public static State Evolve(State state, Event message) =>
        (state, message) switch
        {
            (Process.State.Initial, Event.Received<Input>(Input.NewOrder m)) =>
                new State.PreparingDrink(
                    $"{m.Size}, {m.Name}",
                    m.Name
                ),
            (Process.State.PreparingDrink, Event.Received<Input>(Input.PaymentComplete m)) =>
                new State.Completed(),
            _ => state
        };

    public void Handle(State state, Input message)
    {
        Apply(message.ToEvent());
        switch (state, message)
        {
            case (Process.State.Initial, Input.NewOrder m):
                var drink = $"{m.Size} {m.Item}";
                Console.WriteLine($"{drink} for {m.Name}, got it!");
                Apply(new Output.PrepareDrink(m.CorrelationId, drink, m.Name).Send().ToEvent());
                break;
            case (Process.State.PreparingDrink s, Input.PaymentComplete m):
                Console.WriteLine($"Payment Complete for '{s.Name}' got it!");
                Apply(new Output.DrinkReady(m.CorrelationId, s.Drink, s.Name).Publish().ToEvent());
                Apply(new Output.Complete().Send().ToEvent());
                break;
            default: throw new Exception($"%A{message} can not be handled by %A{state}");
        }
    }
}
