using System.IO;
using System.Xml;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests;

namespace OpenSubtitlesClient.Communication.Serialization
{
    internal class RequestXmlSerializer
    {
        public void Serialize<T>(T request, Stream stream) where T : RequestBase
        {
            var serializer = new XmlSerializer(typeof(T));
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, request, ns);
            }
        }
    }
}
