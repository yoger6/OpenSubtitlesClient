namespace OpenSubtitlesClient.Communication.Responses
{
    public class IdentifiedLanguage
    {
        public IdentifiedLanguage(string requestedString, string language)
        {
            RequestedString = requestedString;
            Language = language;
        }

        /// <summary>
        /// MD5 hashed
        /// </summary>
        public string RequestedString { get; }

        /// <summary>
        /// 3 Letter language identifier.
        /// </summary>
        public string Language { get; }
    }
}