using System.Collections;
using System.Collections.Generic;

namespace CommunicationFunctionalTests.RequestTests
{
    internal class RequestTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[] { new RequestTestMember(TestRequestFactory.AddCommentRequest(), "AddCommentRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.AutoUpdateRequest(), "AutoUpdateRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.CheckMovieHashRequest(), "CheckMovieHashRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.CheckSubHashRequest(), "CheckSubHashRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.DetectLanguageRequest(), "DetectLanguageRawRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.DownloadSubtitlesRequest(), "DownloadSubtitlesRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.GetAvailableTranslationsRequest(), "GetAvailableTranslationsRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.GetImdbMovieDetailsRequest(), "GetImdbMovieDetailsRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.GetSubLanguageRequest(), "GetSubLanguagesRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.GetTranslationRequest(), "GetTranslationRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.InsertMovieRequest(), "InsertMovieRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.LoginRequest(), "LoginRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.LogoutRequest(), "LogoutRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.NoOperationRequest(), "NoOperationRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.ReportWrongMovieHashRequest(), "ReportWrongMovieHashRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.SearchMoviesOnImdbRequest(), "SearchMoviesOnImdbRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.SearchSubtitlesRequest(), "SearchSubtitlesRequest") };
            // TODO investigate and implement: yield return new[] { new RequestTestMember(TestRequestFactory.SearchToMailRequest(), "SearchToMailRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.ServerInfoRequest(), "ServerInfoRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.SubtitlesVoteRequest(), "SubtitlesVoteRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.TryUploadSubtitlesRequest(), "TryUploadSubtitlesRequest") };
            yield return new[] { new RequestTestMember(TestRequestFactory.UploadSubtitlesRequest(), "UploadSubtitlesRequest") };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}