using OpenSubtitlesClient.Communication.Requests;

namespace CommunicationFunctionalTests.RequestTests
{
    public class RequestTestMember
    {
        public RequestBase Request { get; }
        public string TemplateName { get; }

        public RequestTestMember(RequestBase request, string templateName)
        {
            Request = request;
            TemplateName = templateName;
        }
    }
}