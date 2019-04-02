using System.Xml;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public class ResponseIntParameterValue : ResponseParameterValueBase
    {
        private object _value;

        public override T GetValue<T>()
        {
            return (T) _value;
        }

        public override void ReadXml(XmlReader reader)
        {
            reader.Read();
            _value = int.Parse(reader.Value);

            base.ReadXml(reader);
        }

        protected override string NodeName => "int";
    }
}