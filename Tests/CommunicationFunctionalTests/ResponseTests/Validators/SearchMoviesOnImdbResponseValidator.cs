using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class SearchMoviesOnImdbResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (SearchMoviesOnImdbResponse)response;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.622, r.Time.Seconds);
            Assert.Contains(r.Results, m => m.Id == 0088763 && m.Title == "Back to the Future (1985)");
            Assert.Contains(r.Results, m => m.Id == 0096874 && m.Title == "Back to the Future Park II (1989)");
        }
    }
}