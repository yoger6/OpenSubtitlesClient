using System.Collections.Generic;
using System.Linq;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class ImdbMovieDetails
    {
        public ImdbMovieDetails(
            string id, 
            string title, 
            string year, 
            string cover, 
            IEnumerable<ImdbPerson> cast, 
            IEnumerable<ImdbPerson> directors, 
            IEnumerable<ImdbPerson> writers, 
            string awards, 
            IEnumerable<Genre> genres, 
            IEnumerable<Country> countries, 
            IEnumerable<Language> languages,
            string duration,
            IEnumerable<Country> certification,
            string tagline,
            string plot,
            string goofs,
            string trivia,
            string requestFrom)
        {
            Id = int.Parse(id);
            Title = title;
            Cover = cover;
            Awards = awards;
            TagLine = tagline;
            Plot = plot;
            Goofs = goofs;
            Trivia = trivia;
            RequestFrom = requestFrom;
            Year = int.Parse(year);
            Cast = cast.ToArray();
            Directors = directors.ToArray();
            Writers = writers.ToArray();
            Genres = genres.ToArray();
            Countries = countries.ToArray();
            Languages = languages.ToArray();
            Duration = new Duration(duration);
            Certifications = certification.ToArray();
        }

        public int Id { get; }
        public string Title { get; }
        public int Year { get; }
        public string Cover { get; }
        public ImdbPerson[] Cast { get; }
        public ImdbPerson[] Directors { get; }
        public ImdbPerson[] Writers { get; }
        public string Awards { get; }
        public Genre[] Genres { get; }
        public Country[] Countries { get; }
        public Language[] Languages { get; }
        public Country[] Certifications { get; }
        public string TagLine { get; }
        public string Plot { get; }
        public string Goofs { get; }
        public string Trivia { get; }
        public string RequestFrom { get; }

        public Duration Duration { get; }
    }
}