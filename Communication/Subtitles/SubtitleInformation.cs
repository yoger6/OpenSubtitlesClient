namespace Communication.Subtitles
{
    public class SubtitleInformation
    {
        public string Hash { get; }
        public string FileName { get; }
        public string Content { get; }

        public SubtitleInformation(string hash, string fileName, string content = null)
        {
            Hash = hash;
            FileName = fileName;
            Content = content;
        }
    }
}