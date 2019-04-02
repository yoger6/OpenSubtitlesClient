using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     This function can be used to download multiple subtitle files at once.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class DownloadSubtitlesRequest : RequestBase
    {
        public DownloadSubtitlesRequest()
        {
        }

        public DownloadSubtitlesRequest(Token token, params SubtitleIdentifier[] identifiers)
            : base(
                "DownloadSubtitles",
                RequestParameter.Token(token),
                SubtitleIdentifiers(identifiers))
        {
        }

        private static RequestParameter SubtitleIdentifiers(SubtitleIdentifier[] identifiers)
        {
            var data = identifiers.Select(x => RequestParameterValue.Int(x.Value)).ToArray();

            return RequestParameter.Create(RequestParameterValue.Array(data));
        }
    }
}