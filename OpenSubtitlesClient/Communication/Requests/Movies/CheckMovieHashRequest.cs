using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Movies
{
    /// <summary>
    ///     Checks if given video file hashes hashes are already stored in the database.
    ///     If found, the server will return basic movie information, including IMDb ID, movie title, release year.
    ///     This information can be then used in client application to automatically fill(or verify) movie info.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class CheckMovieHashRequest : RequestBase
    {
        public CheckMovieHashRequest()
        {
        }

        public CheckMovieHashRequest(Token token, params string[] hashes)
            : base(
                "CheckMovieHash",
                RequestParameter.Token(token),
                RequestParameter.Strings(hashes))
        {
        }
    }
}