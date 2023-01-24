namespace EventSourcedSaga.Barista.Process;

using EventSourcedSaga.Infrastructure.Process;

public class Received__NewOrder : Event.Received<Input.NewOrder>
{
    public Received__NewOrder(Input.NewOrder @in) : base(@in)
    {
    }
}

public class Received__PaymentComplete : Event.Received<Input.PaymentComplete>
{
    public Received__PaymentComplete(Input.PaymentComplete @in) : base(@in)
    {
    }
}

public class Published__DrinkReady : Event.Published<Output.DrinkReady>
{
    public string Drink { get; set; }
    public string Name { get; set; }


    public Published__DrinkReady(Output.DrinkReady @out) : base(@out)
    {
        Drink = @out.Drink;
        Name = @out.Name;
    }
}

public class Sent__PrepareDrink : Event.Sent<Output.PrepareDrink>
{
    public string Drink { get; set; }
    public string Name { get; set; }


    public Sent__PrepareDrink(Output.PrepareDrink @out) : base(@out)
    {
        Drink = @out.Drink;
        Name = @out.Name;
    }
}

public class Completed : Event.Completed
{

}
