using OpenSubtitlesClient.Communication.Validation;

namespace OpenSubtitlesClient.Communication.Requests
{
    public class ImdbQuery
    {
        public string Expression { get; }

        public ImdbQuery(string expression)
        {
            Assure.NotEmpty(expression, nameof(expression));
            Expression = expression;
        }
    }
}
