using System.Collections.Generic;
using Communication.Events;

namespace Communication.Subtitles
{
    public class TryUploadSubtitlesCommand : Command<TryUploadSubtitlesRawRequest>
    {
        private readonly IList<SubtitleFile> _subtitles;
        private readonly string _token;

        public TryUploadSubtitlesCommand(IList<SubtitleFile> subtitles, string token)
        {
            _subtitles = subtitles;
            _token = token;
        }

        protected override void OnValidationError(IEventHub hub, ValidationException e)
        {
            hub.Publish(new SubtitlesUploadNotTried());
        }

        protected override void OnCommunicationFailure(IEventHub hub, CommunicationException e)
        {
            hub.Publish(new SubtitlesUploadNotTried());
        }

        protected override void OnSuccess(IEventHub hub)
        {
            hub.Publish(new SubtitlesUploadTried());
        }

        protected override TryUploadSubtitlesRawRequest GetRequest(IRequestFactory factory)
        {
            return factory.CreateTryUploadSubtitlesRequest(_subtitles, _token);
        }
    }
}