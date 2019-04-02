using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Requests.Movies;
using OpenSubtitlesClient.Communication.Requests.Server;
using OpenSubtitlesClient.Communication.Validation;

namespace OpenSubtitlesClient.Communication
{
    public static class RequestFactory
    {
        private const int HashLength = 26;

        public static RequestBase SearchMoviesOnImdb(Token token, ImdbQuery query)
        {
            Assure.NotNull(token, nameof(token));
            Assure.NotNull(query, nameof(query));

            return new SearchMoviesOnImdbRequest(token, query);
        }

        public static RequestBase InsertMovie(Token token, string title, int year)
        {
            Assure.NotNull(token, nameof(token));
            Assure.NotNull(title, nameof(title));
            Assure.NotEmpty(title, nameof(title));
            Assure.GreaterThanZero(year, nameof(year));

            return new InsertMovieRequest(token, title, year);
        }

        public static RequestBase GetImdbMovieDetails(Token token, string movieId)
        {
            Assure.NotNull(token, nameof(token));
            Assure.NotNull(movieId, nameof(movieId));
            Assure.NotEmpty(movieId, nameof(movieId));

            return new GetImdbMovieDetailsRequest(token, movieId);
        }


        public static RequestBase CheckMovieHash(Token token, params string[] hashes)
        {
            Assure.NotNull(token, nameof(token));
            Assure.NotNull(hashes, nameof(hashes));
            Assure.NotEmpty(hashes, nameof(hashes));
            AssureAll.HaveLength(hashes, HashLength, nameof(hashes));

            return new CheckMovieHashRequest(token, hashes);
        }

        public static RequestBase ServerInformation()
        {
            return new ServerInformationRequest();
        }

        public static RequestBase NoOperation(Token token)
        {
            return new NoOperationRequest();
        }
    }
}
