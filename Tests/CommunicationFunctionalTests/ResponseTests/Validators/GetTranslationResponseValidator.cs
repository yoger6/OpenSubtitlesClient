using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class GetTranslationResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (GetTranslationResponse) response;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(3.824, r.Time.Seconds);
            Assert.Equal("gzipped and base64-encoded language file contents", r.Translation);
        }
    }
}