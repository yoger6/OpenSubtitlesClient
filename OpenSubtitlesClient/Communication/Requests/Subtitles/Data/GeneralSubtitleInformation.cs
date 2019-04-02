namespace OpenSubtitlesClient.Communication.Requests.Subtitles.Data
{
    public class GeneralSubtitleInformation
    {
        public string ImdbId { get; }
        public LanguageCode SubtitleLanguage { get; }
        public string MovieFileName { get; }
        public string MovieAlsoKnownAs { get; }
        public string Comment { get; }

        public GeneralSubtitleInformation(string imdbId, LanguageCode subtitleLanguage, string movieFileName, string movieAlsoKnownAs, string comment)
        {
            ImdbId = imdbId;
            SubtitleLanguage = subtitleLanguage;
            MovieFileName = movieFileName;
            MovieAlsoKnownAs = movieAlsoKnownAs;
            Comment = comment;
        }
    }
}