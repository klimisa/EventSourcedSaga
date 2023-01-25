namespace EventSourcedSaga.Barista.Process;

using Infrastructure.Process;

public static class Extensions
{
    public static Event ToEvent(this Command command) =>
        command switch
        {
            Command.Send<Output>(Output.PrepareDrink m) => new Sent__PrepareDrink(m),
            Command.Publish<Output>(Output.DrinkReady m) => new Published__DrinkReady(m),
            Command.Complete => new Completed(),
            _ => throw new ArgumentOutOfRangeException(nameof(command), command, null)
        };

    public static Event ToEvent(this Input message) =>
        message switch
        {
            Input.NewOrder m => new Received__NewOrder(m),
            Input.PaymentComplete m => new Received__PaymentComplete(m),
            _ => throw new ArgumentOutOfRangeException(nameof(message), message, null)
        };
}
