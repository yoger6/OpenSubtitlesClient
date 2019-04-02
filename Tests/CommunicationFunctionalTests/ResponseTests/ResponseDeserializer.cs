using CommunicationFunctionalTests.IO;
using OpenSubtitlesClient.Communication.Responses;
using OpenSubtitlesClient.Communication.Serialization;

namespace CommunicationFunctionalTests.ResponseTests
{
    internal static class ResponseDeserializer
    {
        public static T Deserialize<T>(string responseName) where T : ResponseBase
        {
            var relativeFileLocation = $@"ResponseTests\SampleResponseFiles\{responseName}.xml";
            var responseStream = TestFileStreamer.StreamFileContent(relativeFileLocation);
            var deserializer = new ResponseXmlDeserializer();

            return deserializer.Deserialize<T>(responseStream);
        }
    }
}