using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class ResponseParameters
    {
        [XmlElement("param")]
        public ResponseParameter Parameter { get; set; }
    }
}