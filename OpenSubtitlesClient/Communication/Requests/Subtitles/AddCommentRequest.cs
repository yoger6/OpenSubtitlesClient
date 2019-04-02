using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     Allows registered users to add a new comment to subtitle.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class AddCommentRequest : RequestBase
    {
        public AddCommentRequest()
        {
        }

        public AddCommentRequest(Token token, int subtitleId, string comment, bool isBadSubtitle)
            : base(
                "AddComment",
                RequestParameter.Token(token),
                RequestParameter.Create(
                    RequestParameterValue.Struct(
                        RequestParameterValue.Member("idsubtitle", RequestParameterValue.Int(subtitleId)),
                        RequestParameterValue.Member("comment", RequestParameterValue.String(comment)),
                        RequestParameterValue.Member("badsubtitle", RequestParameterValue.Int(isBadSubtitle)))))
        {
        }
    }
}