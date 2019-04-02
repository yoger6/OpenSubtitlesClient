using System.Linq;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class GetSubLanguagesResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = (GetSubLanguagesResponse)response;
            var l = r.SupportedLanguages.Single();

            //Assert.Equal(HttpStatusCode.OK, r.Status.Code); TODO: verify, there should be a code
            Assert.Equal(0.024, r.Time.Seconds);
            Assert.Equal("eng", l.LanguageId);
            Assert.Equal("English", l.Name);
            Assert.Equal(LanguageCode.en, l.Code);
        }
    }
}