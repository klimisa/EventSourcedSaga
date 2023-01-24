namespace EventSourcedSaga.Barista.Process;

using Eventuous.Process;

public record DrinkPreparationId: ProcessId
{
    public DrinkPreparationId(string value) : base(value)
    {
    }
}
