using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;
using OpenSubtitlesClient.Communication.Serialization.Parameters;

namespace OpenSubtitlesClient.Communication.Requests
{
    public class RequestBase
    {
        [XmlIgnore]
        public const string RootNodeName = "methodCall";

        [XmlElement("methodName")]
        public Method MethodName { get; set; }

        [XmlArray(ElementName = "params")]
        [XmlArrayItem("param")]
        public RequestParameter[] RequestParameters { get; set; }

        public RequestBase()
        {
        }

        public RequestBase(string methodName, params RequestParameter[] requestParameters)
        {
            MethodName = new Method(methodName);
            RequestParameters = requestParameters;
        }
    }
}