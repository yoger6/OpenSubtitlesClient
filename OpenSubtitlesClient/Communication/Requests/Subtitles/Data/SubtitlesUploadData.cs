using Communication;
using Communication.Subtitles;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles.Data
{
    public class SubtitlesUploadData
    {
        public GeneralSubtitleInformation General { get; }
        public SubtitleFile[] SubtitleFiles { get; }

        public SubtitlesUploadData(
            GeneralSubtitleInformation general, 
            params SubtitleFile[] subtitleFiles)
        {
            General = general;
            SubtitleFiles = subtitleFiles;
        }
    }
}