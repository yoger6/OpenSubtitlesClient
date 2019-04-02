using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     This function returns subtitle file IDs for given subtitle file hashes.
    ///     This can be used to quickly check(for a large list of subtitle files)
    ///     which subtitle files are already stored in the database(e.g.before uploading).
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class CheckSubHashRequest : RequestBase
    {
        public CheckSubHashRequest()
        {
        }

        public CheckSubHashRequest(Token token, params string[] hashes)
            : base(
                "CheckSubHash",
                RequestParameter.Token(token),
                RequestParameter.Strings(hashes))
        {
        }
    }
}