using System.Collections.Generic;
using Communication.Common;
using Communication.Subtitles;

namespace Communication
{
    public interface IRequestFactory
    {
        UploadSubtitlesRawRequest CreateUploadSubtitlesRequest(string imdbId, LanguageCode language, string movieFileName,
            string movieKnownAs, string comment, IList<SubtitleFile> files, string token);

        TryUploadSubtitlesRawRequest CreateTryUploadSubtitlesRequest(IList<SubtitleFile> subtitles, string token);
    }
}