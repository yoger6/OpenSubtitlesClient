using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class ReportWrongMovieHashResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (ReportWrongMovieHashResponse)response;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.703, r.Time.Seconds);
        }
    }
}