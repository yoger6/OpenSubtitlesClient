using System.Linq;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Requests.Parameters
{
    public class RequestParameter
    {
        [XmlElement("value")]
        public RequestParameterValueBase Value { get; set; }

        public RequestParameter()
        {
        }

        private RequestParameter(RequestParameterValueBase value)
        {
            Value = value;
        }

        public static RequestParameter Create(RequestParameterValueBase value)
        {
            return new RequestParameter(value);
        }

        public static RequestParameter Token(Token token)
        {
            return Create(RequestParameterValue.String(token.Value));
        }

        public static RequestParameter Strings(string[] strings)
        {
            var data = strings.Select(RequestParameterValue.String).ToArray();
            return Create(RequestParameterValue.Array(data));
        }
    }
}