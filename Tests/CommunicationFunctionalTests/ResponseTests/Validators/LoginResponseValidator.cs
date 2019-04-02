using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class LoginResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as LoginResponse;

            Assert.Equal("token", r.Token.Value);
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(1.0, r.Time.Seconds);
        }
    }
}