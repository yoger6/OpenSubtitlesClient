using System.IO;
using System.Reflection;
using CommunicationFunctionalTests.IO;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Serialization;

namespace CommunicationFunctionalTests.RequestTests
{
    internal static class SerializedRequestComparer
    {
        public static void MakeSureSerializedRequestIsCompliantWithTemplate(RequestBase request, string requestTemplateName)
        {
            var actualRequestType = request.GetType();
            var method = typeof(SerializedRequestComparer).GetMethod(nameof(VerifyResponse), BindingFlags.Static | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(actualRequestType);
            generic.Invoke(null, new object[] { request, requestTemplateName });
        }

        private static void VerifyResponse<T>(T request, string requestTemplateName) where T : RequestBase
        {
            var relativeFileLocation = $@"RequestTests\SampleRequestFiles\{requestTemplateName}.xml";
            var serializer = new RequestXmlSerializer();
            using (var expectedContent = TestFileStreamer.StreamFileContent(relativeFileLocation))
            using (var actualContent = new MemoryStream())
            {
                serializer.Serialize(request, actualContent);
                actualContent.Seek(0, SeekOrigin.Begin);

                StreamContent.AreEqual(expectedContent, actualContent);
            }
        }
    }
}