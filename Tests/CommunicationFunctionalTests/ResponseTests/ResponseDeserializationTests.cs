using System;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using CommunicationFunctionalTests.IO;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;
using OpenSubtitlesClient.Communication.Responses;
using OpenSubtitlesClient.Communication.Serialization;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests
{
    public class ResponseDeserializationTests
    {
        private const string PathBase = @"ResponseTests\SampleResponseFiles\{0}.xml";

        [Theory(Skip = "")]
        [ClassData(typeof(ResponseTestData))]
        public void ResponsesShouldBeDeserializedIntoExpectedObject(ResponseTestMember testData)
        {
            var fullPath = string.Format(PathBase, testData.ResponseType.Name);
            var result = GetDeserializedResponse(testData.ResponseType, fullPath);
            
            testData.Validate(result);
        }

        private object GetDeserializedResponse(Type type, string responseFile)
        {
            var deserializer = new ResponseXmlDeserializer();
            var method = deserializer.GetType().GetMethod(nameof(deserializer.Deserialize));
            var genericMethod = method.MakeGenericMethod(type);
            
            using (var stream = TestFileStreamer.StreamFileContent(responseFile))
            {
                return genericMethod.Invoke(deserializer, new object[] { stream });
            }
        }
    }
}
