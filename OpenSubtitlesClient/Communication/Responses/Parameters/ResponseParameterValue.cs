using System;
using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseParameterValue : ResponseParameterValueBase
    {
        public ResponseStructParameterValue Struct { get; set; }

        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            Struct = new ResponseStructParameterValue();
            Struct.ReadXml(reader);
            base.ReadXml(reader);
        }

        public override T GetValue<T>()
        {
            throw new NotSupportedException("Parameters don't have direct value. They're just container elements.");
        }

        protected override string NodeName => "param";
    }
}