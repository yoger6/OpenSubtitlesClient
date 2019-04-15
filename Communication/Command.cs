using Communication.DataSource;
using Communication.Events;

namespace Communication
{
    public abstract class Command<TRequest>
    {
        public void Execute(IEventHub hub, IOpenSubtitlesClient client, IRequestFactory requestFactory)
        {
            try
            {
                var request = GetRequest(requestFactory);
                client.Send(request);

                OnSuccess(hub);
            }
            catch (CommunicationException e)
            {
                OnCommunicationFailure(hub, e);
            }
            catch (ValidationException e)
            {
                OnValidationError(hub, e);
            }
        }

        protected virtual void OnValidationError(IEventHub hub, ValidationException e)
        {
            hub.Publish(new CommandFailure());
        }

        protected virtual void OnCommunicationFailure(IEventHub hub, CommunicationException e)
        {
            hub.Publish(new CommandFailure());
        }

        protected virtual void OnSuccess(IEventHub hub)
        {
            hub.Publish(new CommandSuccess());
        }

        protected abstract TRequest GetRequest(IRequestFactory factory);

        public class CommandSuccess
        {
        }

        public class CommandFailure
        {
        }
    }
}