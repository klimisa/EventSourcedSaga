namespace EventSourcedSaga.Barista.Process;

public record State
{
    public record Initial : State;

    public record PreparingDrink(string Drink, string Name) : State;

    public record Completed : State;
};
