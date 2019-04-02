using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class NoOperationResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (NoOperationResponse)response;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.005, r.Time.Seconds);
        }
    }
}