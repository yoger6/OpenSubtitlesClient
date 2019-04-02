using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Movies
{
    /// <summary>
    ///     Returns structure with movie information about given imdb movie containing
    ///     movie title, release year, directors, cast, ...
    ///     All information is gathered from ​IMDb
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class GetImdbMovieDetailsRequest : RequestBase
    {
        public GetImdbMovieDetailsRequest()
        {
        }

        public GetImdbMovieDetailsRequest(Token token, string movieId)
            : base(
                "GetIMDBMovieDetails",
                RequestParameter.Token(token),
                RequestParameter.Create(RequestParameterValue.String(movieId)))
        {
        }
    }
}