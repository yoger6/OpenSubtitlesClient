using System.Collections.Generic;
using Communication.Common;
using Communication.Events;

namespace Communication.Subtitles
{
    public class SubtitlesUploadCommand : Command<UploadSubtitlesRawRequest>
    {
        private readonly string _imdbId;
        private readonly LanguageCode _language;
        private readonly string _movieFileName;
        private readonly string _movieKnownAs;
        private readonly string _comment;
        private readonly string _token;
        private readonly IList<SubtitleFile> _files;

        public SubtitlesUploadCommand(string imdbId, LanguageCode language, string movieFileName, string movieKnownAs, string comment, string token)
        {
            _imdbId = imdbId;
            _language = language;
            _movieFileName = movieFileName;
            _movieKnownAs = movieKnownAs;
            _comment = comment;
            _token = token;
            _files = new List<SubtitleFile>();
        }

        public void AddSubtitles(SubtitleFile file)
        {
            _files.Add(file);
        }

        protected override void OnValidationError(IEventHub hub, ValidationException e)
        {
            hub.Publish(new SubtitlesNotUploaded(e.Message));
        }

        protected override void OnCommunicationFailure(IEventHub hub, CommunicationException e)
        {
            hub.Publish(new SubtitlesNotUploaded(e.Message));
        }

        protected override void OnSuccess(IEventHub hub)
        {
            hub.Publish(new SubtitlesUploaded());
        }

        protected override UploadSubtitlesRawRequest GetRequest(IRequestFactory factory)
        {
            return factory.CreateUploadSubtitlesRequest(
                _imdbId, _language, _movieFileName, _movieKnownAs, _comment, _files, _token);
        }
    }
}
