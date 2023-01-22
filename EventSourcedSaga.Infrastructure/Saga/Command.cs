namespace EventSourcedSaga.Infrastructure.Saga;

public record Command
{
    public record Reply<TOutput>(TOutput TOut) : Command;

    public record Send<TOutput>(TOutput TOut) : Command;

    public record Schedule<TOutput>(TOutput TOut, TimeSpan OnTime) : Command;

    public record Publish<TOutput>(TOutput TOut) : Command;

    public record Complete : Command;
}
