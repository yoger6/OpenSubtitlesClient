using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     Allows registered users to rate subtitle idsubtitle giving a score score where 1 is worst and 10 is best.
    ///     Users cannot rate subtitles they uploaded and each user can rate a specific subtitle only once.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class SubtitlesVoteRequest : RequestBase
    {
        public SubtitlesVoteRequest()

        {
        }

        public SubtitlesVoteRequest(Token token, int subtitleId, int score)
            : base(
                "SubtitlesVote",
                RequestParameter.Token(token),
                RequestParameter.Create(
                    RequestParameterValue.Struct(
                        RequestParameterValue.Member("idsubtitle", RequestParameterValue.Int(subtitleId)),
                        RequestParameterValue.Member("score", RequestParameterValue.Int(score)))))
        {
        }
    }
}