using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class ResponseBase
    {
        protected const string RootName = "methodResponse";

        [XmlIgnore]
        public ResponseStatus Status => new ResponseStatus(GetMember<string>("status"));

        [XmlIgnore]
        public ResponseTime Time => new ResponseTime(GetMember<double>("seconds"));

        [XmlIgnore]
        public IList<ResponseMember> Data
            => Parameters.Parameter
                         .Value
                         .Struct
                         .Members.Single(x => x.Name == "data")
                         .GetValue<IList<ResponseMember>>();

        [XmlIgnore]
        public IList<ResponseStructParameterValue> Array
            => Parameters.Parameter
                         .Value
                         .Struct
                         .Members.Single(x => x.Name == "data")
                         .GetValue<IList<ResponseStructParameterValue>>();
        
        [XmlElement("params")]
        public ResponseParameters Parameters { get; set; }

        protected T GetMember<T>(string name)
        {
            return Parameters.Parameter.Value.Struct.Members.Single(x=>x.Name == name).GetValue<T>();
        }
    }
}
