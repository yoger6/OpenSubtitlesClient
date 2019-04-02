using System.IO;
using System.Xml;
using System.Xml.Serialization;
using CommunicationTests.IO;
using Xunit;

namespace CommunicationTests
{
    public class RequestComplianceTests
    {
        [Fact]
        public void TestRequestCompliance()
        {
            var data = TestRequestFactory.GetTestData();
            VerifyRequestCompliance(data);
        }


        private static void VerifyRequestCompliance(params TestData[] testData)
        {
            foreach (var requestData in testData)
            {
                var fileName = $"{requestData.RequestType.Name.Replace("Raw", string.Empty)}.xml";
                var path = $@"SampleRequestFiles\{fileName}";
                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
                using (var expectedContent = TestFileStreamer.StreamFileContent(path))
                using (var actualContent = new MemoryStream())
                using (var writer = XmlWriter.Create(actualContent, settings))
                {
                    var serializer = new XmlSerializer(requestData.RequestType);
                    var ns = new XmlSerializerNamespaces(new[] { new XmlQualifiedName() });
                    serializer.Serialize(writer, requestData.Request, ns);
                    actualContent.Seek(0, SeekOrigin.Begin);

                    StreamContent.AreEqual(expectedContent, actualContent);
                }
            }
        }

    }
}
