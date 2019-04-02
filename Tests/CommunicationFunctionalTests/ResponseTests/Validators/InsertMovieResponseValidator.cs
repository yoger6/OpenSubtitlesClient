using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class InsertMovieResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (InsertMovieResponse)response;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.018, r.Time.Seconds);
            Assert.Equal(10000044, r.MovieId);
        }
    }
}