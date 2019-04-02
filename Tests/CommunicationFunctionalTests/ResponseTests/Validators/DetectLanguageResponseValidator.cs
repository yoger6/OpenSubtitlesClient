using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class DetectLanguageResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as DetectLanguageResponse;
            var id = r.IdentifiedLanguages[0];

            Assert.Equal("MD5 of requested string", id.RequestedString);
            Assert.Equal("eng", id.Language);
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.425, r.Time.Seconds);
        }
    }
}