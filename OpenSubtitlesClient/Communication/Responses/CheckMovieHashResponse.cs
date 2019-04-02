using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class CheckMovieHashResponse : ResponseBase
    {
        [XmlIgnore]
        public BasicMovieInformation[] MovieInfomration => ParseMovieInformation().ToArray();

        private IEnumerable<BasicMovieInformation> ParseMovieInformation()
        {
            foreach (var member in Data)
            {
                var parameters = member.GetValue<IList<ResponseMember>>();
                var name = parameters.Single(x => x.Name == "MovieName").GetValue<string>();
                var year = parameters.Single(x => x.Name == "MovieYear").GetValue<string>();
                var imdbId = parameters.Single(x => x.Name == "MovieImdbID").GetValue<string>();
                var hash = parameters.Single(x => x.Name == "MovieHash").GetValue<string>();

                yield return new BasicMovieInformation(name, int.Parse(year), imdbId, hash);
            }
        }
    }

    public class BasicMovieInformation
    {
        public BasicMovieInformation(string name, int year, string imdbId, string hash)
        {
            Name = name;
            Year = year;
            ImdbId = imdbId;
            Hash = hash;
        }

        public string Name { get; }

        public int Year { get; }

        public string ImdbId { get; }

        public string Hash { get; }
    }
}