using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseParameter
    {
        [XmlElement("value")]
        public ResponseParameterValue Value { get; set; }
    }
}