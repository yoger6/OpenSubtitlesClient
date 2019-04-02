using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Movies
{
    /// <summary>
    ///     Searches for movies matching given movie title query.
    ///     Returns array of movies data found on IMDb.com and in internal server movie database.
    ///     Manually added movies can be identified by ID starting at 10000000.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class SearchMoviesOnImdbRequest : RequestBase
    {
        public SearchMoviesOnImdbRequest()
        {
        }

        public SearchMoviesOnImdbRequest(Token token, ImdbQuery query)
            : base(
                "SearchMoviesOnIMDB",
                RequestParameter.Token(token),
                RequestParameter.Create(RequestParameterValue.String(query.Expression)))
        {
        }
    }
}