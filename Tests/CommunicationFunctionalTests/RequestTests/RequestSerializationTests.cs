using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CommunicationFunctionalTests.IO;
using OpenSubtitlesClient.Communication.Requests.Subtitles;
using OpenSubtitlesClient.Communication.Serialization;
using Xunit;

namespace CommunicationFunctionalTests.RequestTests
{
    public class RequestSerializationTests
    {
        [Theory]
        [ClassData(typeof(RequestTestData))]
        public void RequestShouldSerializeIntoExpectedXml(RequestTestMember testMember)
        {
            SerializedRequestComparer.MakeSureSerializedRequestIsCompliantWithTemplate(testMember.Request, testMember.TemplateName);
        }

    }
}