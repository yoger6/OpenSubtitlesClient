using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Server
{
    [XmlRoot(RootNodeName)]
    public class LogoutRequest : RequestBase
    {
        public LogoutRequest()
        {
        }

        public LogoutRequest(Token token)
            : base(
                "LogOut",
                RequestParameter.Token(token))
        {
        }
    }
}
