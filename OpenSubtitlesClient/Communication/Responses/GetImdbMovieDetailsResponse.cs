using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class GetImdbMovieDetailsResponse : ResponseBase
    {
        public ImdbMovieDetails Movie => BuildMovieDetails();

        private ImdbMovieDetails BuildMovieDetails()
        {
            var id = GetDataMemberValue<string>("id");
            var title = GetDataMemberValue<string>("title");
            var year = GetDataMemberValue<string>("year");
            var cover = GetDataMemberValue<string>("cover");
            var cast = GetDataMemberValue<IList<ResponseMember>>("cast")
                .Select(x=> new ImdbPerson(x.Name, x.GetValue<string>()));
            var directors = GetDataMemberValue<IList<ResponseMember>>("directors")
                .Select(x => new ImdbPerson(x.Name, x.GetValue<string>()));
            var writers = GetDataMemberValue<IList<ResponseMember>>("writers")
                .Select(x => new ImdbPerson(x.Name, x.GetValue<string>()));
            var awards = GetDataMemberValue<string>("awards");
            var genres = GetDataMemberValue<IList<string>>("genres")
                .Select(x=> new Genre(x));
            var countries = GetDataMemberValue<IList<string>>("country")
                .Select(x => new Country(x));
            var languages = GetDataMemberValue<IList<string>>("language")
                .Select(x => new Language(x));
            var duration = GetDataMemberValue<string>("duration");
            var certification = GetDataMemberValue<IList<string>>("certification")
                .Select(x => new Country(x));
            var tagline = GetDataMemberValue<string>("tagline");
            var plot = GetDataMemberValue<string>("plot");
            var goofs = GetDataMemberValue<string>("goofs");
            var trivia = GetDataMemberValue<string>("trivia");
            var requestFrom = GetDataMemberValue<string>("request_from");

            return new ImdbMovieDetails(id, title, year, cover, cast, directors, writers, awards, genres, countries, languages, duration, certification, tagline, plot, goofs, trivia, requestFrom);
        }

        private T GetDataMemberValue<T>(string key)
        {
            return Data.Single(x => x.Name == key).GetValue<T>();
        }
    }
}