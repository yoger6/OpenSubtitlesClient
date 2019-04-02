using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class AddCommentResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as AddCommentResponse;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.955, r.Time.Seconds);
        }
    }
}