namespace OpenSubtitlesClient.Communication.Requests.Subtitles.Data
{
    public class UploadSubtitlesRequestData
    {
        public GeneralSubtitleInformation General { get; }
        public SubtitleFile[] SubtitleFiles { get; }

        public UploadSubtitlesRequestData(
            GeneralSubtitleInformation general, 
            params SubtitleFile[] subtitleFiles)
        {
            General = general;
            SubtitleFiles = subtitleFiles;
        }
    }
}