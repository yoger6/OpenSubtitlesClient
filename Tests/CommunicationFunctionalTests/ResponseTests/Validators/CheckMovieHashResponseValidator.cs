using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class CheckMovieHashResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as CheckMovieHashResponse;
            var firstMovie = r.MovieInfomration[0];
            var secondMovie = r.MovieInfomration[1];

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(3.525, r.Time.Seconds);

            VerifyMovieInformation(firstMovie, "firstHash", "1", "Iron Man", 2008);
            VerifyMovieInformation(secondMovie, "secondHash", "2", "Terminator", 1984);
        }

        private static void VerifyMovieInformation(BasicMovieInformation information, string hash, string imdbId, string name, int year)
        {
            Assert.Equal(information.Hash, hash);
            Assert.Equal(information.ImdbId, imdbId);
            Assert.Equal(information.Name, name);
            Assert.Equal(information.Year, year);
        }
    }
}