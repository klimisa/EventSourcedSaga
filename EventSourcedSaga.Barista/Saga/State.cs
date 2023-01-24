namespace EventSourcedSaga.Barista.Saga;

public record State
{
    public record Initial : State;

    public record PreparingDrink(string Drink, string Name) : State;

    public record WaitingForPayment : State;

    public record Completed : State;

    public record WaitForDrinkAndPayment(bool DrinkReady, bool PaymentComplete);
};
