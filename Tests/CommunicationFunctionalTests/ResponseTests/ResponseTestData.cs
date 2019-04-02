using System.Collections;
using System.Collections.Generic;
using CommunicationFunctionalTests.ResponseTests.Validators;
using OpenSubtitlesClient.Communication.Responses;

namespace CommunicationFunctionalTests.ResponseTests
{
    internal class ResponseTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ResponseTestMember(typeof(AddCommentResponse), new AddCommentResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(AutoUpdateResponse), new AutoUpdateResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(CheckMovieHashResponse), new CheckMovieHashResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(CheckSubHashResponse), new CheckSubHashResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(DetectLanguageResponse), new DetectLanguageResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(DownloadSubtitlesResponse), new DownloadSubtitlesResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(GetAvailableTranslationsResponse), new GetAvailableTranslationsResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(GetImdbMovieDetailsResponse), new GetImdbMovieDetailsResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(GetSubLanguagesResponse), new GetSubLanguagesResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(GetTranslationResponse), new GetTranslationResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(InsertMovieResponse), new InsertMovieResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(LoginResponse), new LoginResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(LogoutResponse), new LogoutResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(NoOperationResponse), new NoOperationResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(ReportWrongMovieHashResponse), new ReportWrongMovieHashResponseValidator()) };
            yield return new object[] { new ResponseTestMember(typeof(SearchMoviesOnImdbResponse), new SearchMoviesOnImdbResponseValidator()) };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}