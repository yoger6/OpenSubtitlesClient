using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Movies
{
    /// <summary>
    ///     Allows registered users to insert new movies (not stored in IMDb) to the database.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class InsertMovieRequest : RequestBase
    {
        public InsertMovieRequest()
        {
        }

        public InsertMovieRequest(Token token, string title, int year)
            : base(
                "InsertMovie",
                RequestParameter.Token(token),
                RequestParameter.Create(
                    RequestParameterValue.Struct(
                        RequestParameterValue.Member("moviename", RequestParameterValue.String(title)),
                        RequestParameterValue.Member("movieyear", RequestParameterValue.String(year.ToString())))))
        {
        }
    }
}