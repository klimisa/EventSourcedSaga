namespace EventSourcedSaga.Infrastructure.Saga;

public class Event
{
    public class Received<TInput> : Event
    {
        public Received(TInput @in)
        {
            In = @in;
        }

        public TInput In { get; init; }

        public void Deconstruct(out TInput @in)
        {
            @in = In;
        }
    }

    public class Published<TOutput> : Event
    {
        public Published(TOutput @out)
        {
            Out = @out;
        }

        public TOutput Out { get; init; }

        public void Deconstruct(out TOutput @out)
        {
            @out = Out;
        }
    }

    public class Sent<TOutput> : Event
    {
        public Sent(TOutput @out)
        {
            Out = @out;
        }

        public TOutput Out { get; init; }

        public void Deconstruct(out TOutput @out)
        {
            @out = Out;
        }
    }

    public class Replied<TOutput> : Event
    {
        public Replied(TOutput @out)
        {
            Out = @out;
        }

        public TOutput Out { get; init; }

        public void Deconstruct(out TOutput @out)
        {
            @out = Out;
        }
    }

    public class Completed : Event
    {
    }
}
