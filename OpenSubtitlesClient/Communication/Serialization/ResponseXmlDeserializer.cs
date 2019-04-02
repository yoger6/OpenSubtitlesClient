using System.IO;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Responses;

namespace OpenSubtitlesClient.Communication.Serialization
{
    internal class ResponseXmlDeserializer
    {
        public T Deserialize<T>(Stream response) where T : ResponseBase
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T) serializer.Deserialize(response);
        }
    }
}