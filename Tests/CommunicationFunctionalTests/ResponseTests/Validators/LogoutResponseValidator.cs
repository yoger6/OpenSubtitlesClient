using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class LogoutResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as LogoutResponse;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.2, r.Time.Seconds);
        }
    }
}