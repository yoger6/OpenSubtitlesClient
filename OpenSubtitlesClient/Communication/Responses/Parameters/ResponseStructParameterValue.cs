using System.Collections.Generic;
using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseStructParameterValue : ResponseParameterValueBase
    {
        public readonly IList<ResponseMember> Members = new List<ResponseMember>();

        public override T GetValue<T>()
        {
            return (T)Members;
        }

        public override void ReadXml(XmlReader reader)
        {
            bool hasMore;
            do
            {
                var member = new ResponseMember();
                member.ReadXml(reader);
                Members.Add(member);
                hasMore = reader.ReadToNextSibling("member");

            } while (hasMore);
            
            base.ReadXml(reader);
        }

        protected override string NodeName => "struct";
    }
}