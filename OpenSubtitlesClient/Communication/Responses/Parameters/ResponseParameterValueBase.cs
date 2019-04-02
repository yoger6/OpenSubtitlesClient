using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses.Parameters
{
    public abstract class ResponseParameterValueBase : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            while (!IsEndOfCurrentNode(reader))
            {
                reader.Read();
            }
        }

        private bool IsEndOfCurrentNode(XmlReader reader)
        {
            return reader.NodeType == XmlNodeType.EndElement && reader.Name == NodeName;
        }

        public abstract T GetValue<T>();

        public void WriteXml(XmlWriter writer)
        {
            throw new ResponseSerializationException();
        }

        protected abstract string NodeName { get; }
    }
}