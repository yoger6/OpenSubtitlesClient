using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Serialization.Structure
{
    [XmlRoot("member")]
    public class RequestMember
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("value")]
        public RequestParameterValueBase Value { get; set; }
    }
}