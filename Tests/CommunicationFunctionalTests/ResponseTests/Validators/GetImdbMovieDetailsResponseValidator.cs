using System.Net;
using OpenSubtitlesClient.Communication.Requests.Movies.Data;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class GetImdbMovieDetailsResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as GetImdbMovieDetailsResponse;
            var m = r.Movie;

            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.535, r.Time.Seconds);
            Assert.Equal(0088763, m.Id);
            Assert.Equal("Back to the Future", m.Title);
            Assert.Equal(1985, m.Year);
            Assert.Equal("http://ia.media-imdb.com/images/M/MV5BMTkzNDQyMjc0OV5BMl5BanBnXkFtZTcwNDQ4MDYyMQ@@._V1._SX100_SY133_.jpg", m.Cover);
            VerifyPersonPresence(m.Cast, 0000150, "Michael J. Fox");
            VerifyPersonPresence(m.Cast, 0000502, "Christopher Lloyd");
            VerifyPersonPresence(m.Cast, 0000670, "Lea Thompson");
            VerifyPersonPresence(m.Directors, 0000709, "Robert Zemeckis");
            VerifyPersonPresence(m.Writers, 0000709, "Robert Zemeckis");
            VerifyPersonPresence(m.Writers, 0301826, "Bob Gale");
            Assert.Equal("Won Oscar. Another 12 wins & 22 nominations", m.Awards);
            Assert.Contains(m.Genres, g => g.Equals(Genres.Adventure));
            Assert.Contains(m.Genres, g => g.Equals(Genres.Comedy));
            Assert.Contains(m.Genres, g => g.Equals(Genres.SciFi));
            Assert.Contains(m.Countries, c => c.Equals(Countries.USA));
            Assert.Contains(m.Languages, c => c.Equals(Languages.English));
            Assert.Equal(117, m.Duration.Minutes);
            Assert.Contains(m.Certifications, c => c.Equals(Countries.UK));
            Assert.Contains(m.Certifications, c => c.Equals(Countries.Italy));
            Assert.Contains(m.Certifications, c => c.Equals(Countries.Australia));
            Assert.Contains(m.Certifications, c => c.Equals(Countries.USA));
            Assert.Equal("He's the only kid ever to get into trouble before he was born. [UK]", m.TagLine);
            Assert.Equal("In 1985, Doc Brown invented time travel, in 1955, Marty McFly accidentally prevented his parents from meeting, putting his own existence at stake.", m.Plot);
            Assert.Equal("Continuity: A picture on the table below Biff, and the candy in Biff's hand when he is talking to George about his car in 1985.", m.Goofs);
            Assert.Equal("The space alien gag first appeared in the screenplay's third draft, with the primary difference being that it was to be done to Biff.", m.Trivia);
            Assert.Equal("cache", m.RequestFrom);
        }

        private static void VerifyPersonPresence(ImdbPerson[] people, int id, string name)
        {
            Assert.Contains(people, x => x.Id == id && x.Name == name);
        }
    }
}