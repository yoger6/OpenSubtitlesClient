using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseStringParameterValue : ResponseParameterValueBase
    {
        private object _value;

        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            _value = reader.Value;

            base.ReadXml(reader);
        }

        public override T GetValue<T>()
        {
            return (T)_value;
        }

        protected override string NodeName => "string";
    }
}