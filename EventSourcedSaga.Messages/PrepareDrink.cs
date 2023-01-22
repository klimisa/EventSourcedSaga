namespace EventSourcedSaga.Messages;

public class PrepareDrink
{
    public string Name { get; set; }
    public string Drink { get; set; }
    public Guid CorrelationId { get; set; }
}