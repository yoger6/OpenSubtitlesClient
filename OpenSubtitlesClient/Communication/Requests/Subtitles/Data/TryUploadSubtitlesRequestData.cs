namespace OpenSubtitlesClient.Communication.Requests.Subtitles.Data
{
    public class TryUploadSubtitlesRequestData
    {
        public string Name { get; }
        public SubtitleInformation SubtitleInformation { get; }
        public MovieInformation MovieInformation { get; }

        public TryUploadSubtitlesRequestData(string name, SubtitleInformation subtitleInformation, MovieInformation movieInformation)
        {
            Name = name;
            SubtitleInformation = subtitleInformation;
            MovieInformation = movieInformation;
        }
    }
}