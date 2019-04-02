namespace OpenSubtitlesClient.Communication.Requests.Subtitles.Data
{
    public class SubtitleIdentifier
    {
        public SubtitleIdentifier(int identifier)
        {
            Value = identifier;
        }

        public int Value { get; }
    }
}