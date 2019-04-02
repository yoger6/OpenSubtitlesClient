namespace OpenSubtitlesClient.Communication.Responses
{
    public class SubtitleHash
    {
        public SubtitleHash(string identifier, string hash)
        {
            Identifier = identifier;
            Hash = hash;
        }

        public string Identifier { get; }
        public string Hash { get; }
    }
}