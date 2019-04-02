using System;
using CommunicationFunctionalTests.ContractMembers;
using OpenSubtitlesClient;
using OpenSubtitlesClient.Communication;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Requests.Movies;
using OpenSubtitlesClient.Communication.Requests.Movies.Data;
using OpenSubtitlesClient.Communication.Requests.Server;
using OpenSubtitlesClient.Communication.Requests.Software;
using OpenSubtitlesClient.Communication.Requests.Subtitles;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;

namespace CommunicationFunctionalTests.RequestTests
{
    internal static class TestRequestFactory
    {
        private static readonly Token Token = new TestToken();

        public static RequestBase AddCommentRequest()
        {
            return new AddCommentRequest(Token, 1, "actual comment", false);
        }

        public static RequestBase AutoUpdateRequest()
        {
            return new AutoUpdateRequest("MovieOrganizer");
        }

        public static RequestBase CheckMovieHashRequest()
        {
            return new CheckMovieHashRequest(Token, "first hash", "second hash");
        }

        public static RequestBase CheckSubHashRequest()
        {
            return new CheckSubHashRequest(Token, "first subtitle hash", "second subtitle hash");
        }

        public static RequestBase DetectLanguageRequest()
        {
            return null;
            /*
             *new DetectLanguageRequest(
                Token, "gzipped and then base64-encoded string",
                "second gzipped and then base64-encoded string");
             *
             */
        }

        public static RequestBase DownloadSubtitlesRequest()
        {
            var firstSubtitleId = new SubtitleIdentifier(123);
            var secondSubtitleId = new SubtitleIdentifier(456);

            return new DownloadSubtitlesRequest(Token, firstSubtitleId, secondSubtitleId);
        }

        public static RequestBase GetAvailableTranslationsRequest()
        {
            return new GetAvailableTranslationsRequest(Token, "movie organizer");
        }

        public static RequestBase GetImdbMovieDetailsRequest()
        {
            return new GetImdbMovieDetailsRequest(Token, "id");
        }

        public static RequestBase GetSubLanguageRequest()
        {
            return new GetSubLanguagesRequest(LanguageCode.en);
        }

        public static RequestBase GetTranslationRequest()
        {
            return new GetTranslationRequest(
                Token, "Movie Organizer", TranslationFormat.Mo, LanguageCode.en);
        }

        public static RequestBase InsertMovieRequest()
        {
            return new InsertMovieRequest(Token, "Terminator", 2008);
        }

        public static RequestBase LoginRequest()
        {
            return new LoginRequest("agent", LanguageCode.en, "user", "password");
        }

        public static RequestBase LogoutRequest()
        {
            return new LogoutRequest(Token);
        }

        public static RequestBase NoOperationRequest()
        {
            return new NoOperationRequest(Token);
        }

        public static RequestBase ReportWrongMovieHashRequest()
        {
            return new ReportWrongMovieHashRequest(Token, 39620);
        }

        public static RequestBase SearchMoviesOnImdbRequest()
        {
            return new SearchMoviesOnImdbRequest(Token, new ImdbQuery("back to the future"));
        }

        public static RequestBase SearchSubtitlesRequest()
        {
            var languages = new LanguageList(Languages.English, Languages.German);
            var firstMovieInfo = new MovieHashData(languages, "first hash", 1);
            var secondMovieInfo = new MovieHashData(languages, "second hash", 1);

            return new SearchSubtitlesRequest(Token, firstMovieInfo, secondMovieInfo);
        }

        public static RequestBase SearchToMailRequest()
        {
            throw new NotImplementedException(
                "This case is not documented yet. Needs to be researched,");
        }

        public static RequestBase ServerInfoRequest()
        {
            return new ServerInformationRequest();
        }

        public static RequestBase SubtitlesVoteRequest()
        {
            return new SubtitlesVoteRequest(Token, 3337934, 10);
        }

        public static RequestBase TryUploadSubtitlesRequest()
        {
            return new TryUploadSubtitlesRequest(
                Token, new TryUploadSubtitlesRequestData(
                    "cd1",
                    new SubtitleInformation(
                        "ebe86f4a0357d8c1d635ec49f77e27d6",
                        "almost.heros.1998.dvdrip.xvid.fragment.cze.srt"),
                    new MovieInformation(
                        "89ceb12ab48e3b1f", 731508736, 23.976, 5413204, 129787,
                        "almost.heros.1998.dvdrip.xvid.fragment.avi")));
        }

        public static RequestBase UploadSubtitlesRequest()
        {
            return new UploadSubtitlesRequest(
                Token,
                new UploadSubtitlesRequestData(
                    new GeneralSubtitleInformation(
                        "0119053", LanguageCode.cs, "Almost.Heroes.1998.DVDRip.XviD-FRAGMENT",
                        "the movie", "sumthing"),
                    new SubtitleFile(
                        "cd1",
                        new SubtitleInformation(
                            "ebe86f4a0357d8c1d635ec49f77e27d6",
                            "almost.heroes.1998.dvdrip.xvid.fragment.cze.srt",
                            "eNqMv ... gzipped and then base64-encoded subtitle file contents ... x7cPjA=="),
                        new MovieInformation(
                            "89ceb12ab48e3b1f", 731508736, 23.976, 5413204, 129787,
                            "almost.heroes.1998.dvdrip.xvid.fragment.avi"))
                ));
        }
    }
}