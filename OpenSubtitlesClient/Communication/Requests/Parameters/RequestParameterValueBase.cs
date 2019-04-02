using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Requests.Parameters
{
    public abstract class RequestParameterValueBase : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new RequestDeserializationException();
        }

        public abstract void WriteXml(XmlWriter writer);
    }
}