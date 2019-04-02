using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Requests.Server
{
    /// <summary>
    ///     This function returns a structure with basic server information (urls, contacts) and some statistics,
    ///     including number of users currently online.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class ServerInformationRequest : RequestBase
    {
        public ServerInformationRequest()
            : base("ServerInfo")
        {
        }
    }
}