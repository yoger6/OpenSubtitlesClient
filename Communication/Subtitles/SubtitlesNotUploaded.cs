namespace Communication.Subtitles
{
    public class SubtitlesNotUploaded
    {
        public SubtitlesNotUploaded(string reason)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }
}