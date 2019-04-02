using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class AutoUpdateResponse : ResponseBase
    {
        public string Version => GetMember<string>("version");

        public string UrlWindows => GetMember<string>("url_windows");

        public string Comment => GetMember<string>("comments");
    }
}