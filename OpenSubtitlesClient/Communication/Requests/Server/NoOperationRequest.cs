using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Server
{
    [XmlRoot(RootNodeName)]
    public class NoOperationRequest : RequestBase
    {
        public NoOperationRequest()
        {
        }

        public NoOperationRequest(Token token)
            : base(
                "NoOperation",
                RequestParameter.Token(token))
        {
        }
    }
}