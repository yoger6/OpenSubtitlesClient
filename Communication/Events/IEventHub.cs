namespace Communication.Events
{
    public interface IEventHub
    {
        void Publish<T>(T @event);
    }
}
