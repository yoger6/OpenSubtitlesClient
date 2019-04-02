using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Serialization.Structure
{
    public class Value
    {
        [XmlArray("struct")]
        [XmlArrayItem("member")]
        public RequestMember[] Struct { get; set; }
    }
}