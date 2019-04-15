using System.Collections.Generic;
using Communication.Common;
using Communication.DataSource;
using Communication.Subtitles;

namespace CommunicationTests
{
    internal class TestRequestFactory
    {
        private static readonly OpenSubtitlesRequestFactory Factory = new OpenSubtitlesRequestFactory();

        public static TestData[] GetTestData()
        {
            return new[]
            {
                new TestData(typeof(AddCommentRawRequest), GetAddCommentRequest()), 
                new TestData(typeof(AutoUpdateRawRequest), GetAutoUpdateRequest()), 
                new TestData(typeof(CheckMovieHashRawRequest), GetCheckMovieHashRequest()), 
                new TestData(typeof(CheckSubHashRawRequest), GetCheckSubHashRawRequest()),
                new TestData(typeof(DetectLanguageRawRequest), GetDetectLanguageRequest()), 
                new TestData(typeof(DownloadSubtitlesRawRequest), GetDownloadSubtitlesRequest()), 
                new TestData(typeof(GetAvailableTranslationsRawRequest), GetGetAvailableTranslationsRequest()), 
                new TestData(typeof(GetIMDBMovieDetailsRawRequest), GetGetImdbMovieDetailsRequest()), 
                new TestData(typeof(GetSubLanguagesRawRequest), GetGetSubLanguagesRequest()), 
                new TestData(typeof(GetTranslationRawRequest), GetGetTranslationRequest()), 
                new TestData(typeof(InsertMovieRawRequest), GetInsertMovieRequest()), 
                new TestData(typeof(LoginRawRequest), GetLoginRequest()), 
                new TestData(typeof(LogoutRawRequest), GetLogoutRequest()), 
                new TestData(typeof(NoOperationRawRequest), GetNoOperationRequest()), 
                new TestData(typeof(ReportWrongMovieHashRawRequest), GetReportWrongMovieHashRequest()), 
                new TestData(typeof(SearchMoviesOnIMDBRawRequest), GetSearchMoviesOnImdbRequest()),
                new TestData(typeof(SearchSubtitlesRawRequest), GetSearchSubtitleRequest()),
                new TestData(typeof(ServerInfoRawRequest), GetServerInfoRequest()),
                new TestData(typeof(SubtitlesVoteRawRequest), GetSubtitlesVoteRequest()),
                new TestData(typeof(UploadSubtitlesRawRequest), GetUploadSubtitlesRequest()),
                new TestData(typeof(TryUploadSubtitlesRawRequest), GetTryUploadSubtitlesRawRequest()),
            };
        }

        private static AddCommentRawRequest GetAddCommentRequest()
        {
            return Factory.GetAddCommentRequest(1, "actual comment", false, "token");
        }

        private static AutoUpdateRawRequest GetAutoUpdateRequest()
        {
            return Factory.GetAutoUpdateRequest("MovieOrganizer");
        }

        private static CheckMovieHashRawRequest GetCheckMovieHashRequest()
        {
            return Factory.GetCheckMovieHashRequest(new [] {"first hash", "second hash"}, "token");
        }

        private static CheckSubHashRawRequest GetCheckSubHashRawRequest()
        {
            return Factory.CreateCheckSubHashRequest(new []{ "first subtitle hash", "second subtitle hash" }, "token");
        }

        private static DetectLanguageRawRequest GetDetectLanguageRequest()
        {
            return Factory.CreateDetectLanguageRequest(
                new [] {"gzipped and then base64-encoded string",
                    "second gzipped and then base64-encoded string"},
                "token");
        }

        private static DownloadSubtitlesRawRequest GetDownloadSubtitlesRequest()
        {
            return Factory.CreateDownloadSubtitlesRequest(new uint[] {123,456}, "token");
        }

        private static GetAvailableTranslationsRawRequest GetGetAvailableTranslationsRequest()
        {
            return Factory.CreateGetAvailableTranslationsRequest("movie organizer", "token");
        }

        private static GetIMDBMovieDetailsRawRequest GetGetImdbMovieDetailsRequest()
        {
            return Factory.CreateGetImdbMovieDetailsRequest("id", "token");
        }

        private static GetSubLanguagesRawRequest GetGetSubLanguagesRequest()
        {
            return Factory.CreateGetSubLanguagesRequest(LanguageCode.en);
        }

        private static GetTranslationRawRequest GetGetTranslationRequest()
        {
            return Factory.CreateGetTranslationRequest(LanguageCode.en, TranslationFormat.Mo, "Movie Organizer", "token");
        }

        private static InsertMovieRawRequest GetInsertMovieRequest()
        {
            return Factory.CreateInsertMovieRequest("Terminator", 2008, "token");
        }

        private static LoginRawRequest GetLoginRequest()
        {
            return Factory.CreateLoginRequest("user", "password", LanguageCode.en, "agent");
        }

        private static LogoutRawRequest GetLogoutRequest()
        {
            return Factory.CreateLogoutRequest("token");
        }

        private static NoOperationRawRequest GetNoOperationRequest()
        {
            return Factory.CreateNoOperationRequest("token");
        }

        private static ReportWrongMovieHashRawRequest GetReportWrongMovieHashRequest()
        {
            return Factory.CreateReportWrongMovieHashRequest(39620, "token");
        }

        private static SearchMoviesOnIMDBRawRequest GetSearchMoviesOnImdbRequest()
        {
            return Factory.CreateSearchMoviesOnImdbRequest("back to the future", "token");
        }

        private static UploadSubtitlesRawRequest GetUploadSubtitlesRequest()
        {
            return Factory.CreateUploadSubtitlesRequest(
                "0119053",
                LanguageCode.cs,
                "Almost.Heroes.1998.DVDRip.XviD-FRAGMENT",
                "the movie",
                "sumthing",
                new List<SubtitleFile>
                {
                    new SubtitleFile(
                        "cd1",
                        new SubtitleInformation(
                            "ebe86f4a0357d8c1d635ec49f77e27d6",
                            "almost.heroes.1998.dvdrip.xvid.fragment.cze.srt",
                            "eNqMv ... gzipped and then base64-encoded subtitle file contents ... x7cPjA=="),
                        new MovieInformation(
                            "89ceb12ab48e3b1f",
                            731508736,
                            23.976,
                            5413204,
                            129787,
                            "almost.heroes.1998.dvdrip.xvid.fragment.avi"))
                }, 
                "token");
        }

        private static TryUploadSubtitlesRawRequest GetTryUploadSubtitlesRawRequest()
        {
            return Factory.CreateTryUploadSubtitlesRequest(
                new List<SubtitleFile>
                {
                    new SubtitleFile(
                        "cd1",
                        new SubtitleInformation(
                            "ebe86f4a0357d8c1d635ec49f77e27d6",
                            "almost.heroes.1998.dvdrip.xvid.fragment.cze.srt",
                            "eNqMv ... gzipped and then base64-encoded subtitle file contents ... x7cPjA=="),
                        new MovieInformation(
                            "89ceb12ab48e3b1f",
                            731508736,
                            23.976,
                            5413204,
                            129787,
                            "almost.heroes.1998.dvdrip.xvid.fragment.avi"))
                },
                "token");
        }

        private static SubtitlesVoteRawRequest GetSubtitlesVoteRequest()
        {
            return Factory.CreateSubtitlesVoteRequest(3337934, 10, "token");
        }

        private static ServerInfoRawRequest GetServerInfoRequest()
        {
            return Factory.CreateServerInfoRequest();
        }

        private static SearchSubtitlesRawRequest GetSearchSubtitleRequest()
        {
            return Factory.CreateSearchSubtitlesRequest("token", new[]
            {
                new MovieHashData(
                    new LanguageList(Languages.English, Languages.German),
                    "first hash",
                    1),
                new MovieHashData(
                    new LanguageList(Languages.English, Languages.German),
                    "second hash",
                    1),
            });
        }
    }
}