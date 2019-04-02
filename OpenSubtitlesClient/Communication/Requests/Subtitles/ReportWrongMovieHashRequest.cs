using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     This method is used to report subtitle file - video file combination,
    ///     i.e. subtitle contents are correct but but they are not synchronized to match this video file.
    ///     With this method number of reports is counted in database and after a certain number of reports
    ///     is reached, hash is automatically deleted from the database.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class ReportWrongMovieHashRequest : RequestBase
    {
        public ReportWrongMovieHashRequest()
        {
        }

        /// <param name="token">Session token.</param>
        /// <param name="idSubMovieFile">identifier of the subtitle file video file combination</param>
        public ReportWrongMovieHashRequest(Token token, int idSubMovieFile)
            : base(
                "ReportWrongMovieHash",
                RequestParameter.Token(token),
                RequestParameter.Create(RequestParameterValue.Int(idSubMovieFile)))
        {
        }
    }
}