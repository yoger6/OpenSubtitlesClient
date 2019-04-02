using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class SearchMoviesOnImdbResponse : ResponseBase
    {
        [XmlIgnore]
        public ImdbMovieSearchResult[] Results => ParseResults().ToArray();

        private IEnumerable<ImdbMovieSearchResult> ParseResults()
        {
            foreach (var s in Array)
            {
                var id = s.Members.Single(x => x.Name == "id").GetValue<string>();
                var title = s.Members.Single(x => x.Name == "title").GetValue<string>();

                yield return new ImdbMovieSearchResult(id, title);
            }
        }
    }

    public class ImdbMovieSearchResult
    {
        public ImdbMovieSearchResult(string id, string title)
        {
            Id = int.Parse(id);
            Title = title;
        }

        public int Id { get; }

        public string Title { get; }
    }
}