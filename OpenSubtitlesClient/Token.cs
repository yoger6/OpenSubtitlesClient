using OpenSubtitlesClient.Communication.Validation;

namespace OpenSubtitlesClient
{
    public class Token
    {
        public string Value { get; }

        public Token(string value)
        {
            Assure.NotNull(value, nameof(value));
            Assure.NotEmpty(value, nameof(value));

            Value = value;
        }
    }
}