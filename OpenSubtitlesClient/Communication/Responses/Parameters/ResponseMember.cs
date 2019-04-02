using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseMember : ResponseParameterValueBase
    {
        public string Name { get; private set; }
        
        private ResponseParameterValueBase _value;

        public override void ReadXml(XmlReader reader)
        {
            reader.ReadToFollowing("name");
            Name = reader.ReadElementContentAsString();
            reader.Read();
            switch (reader.Name)
            {
                case "string":
                    _value = new ResponseStringParameterValue();
                    break;
                case "double":
                    _value = new ResponseDoubleParameterValue();
                    break;
                case "struct":
                    _value = new ResponseStructParameterValue();
                    break;
                case "array":
                    _value = new ResponseArrayParameterValue();
                    break;
                case "int":
                    _value = new ResponseIntParameterValue();
                    break;
            }

            _value.ReadXml(reader);
            base.ReadXml(reader);
        }

        public override T GetValue<T>()
        {
            return _value.GetValue<T>();
        }

        protected override string NodeName => "member";
    }
}