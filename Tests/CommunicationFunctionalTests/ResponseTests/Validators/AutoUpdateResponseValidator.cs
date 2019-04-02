using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class AutoUpdateResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as AutoUpdateResponse;

            Assert.Equal("latest application version", r.Version);
            Assert.Equal("http://www.opensubtitles.org/addons/download/app/movieorganizer.zip", r.UrlWindows);
            Assert.Equal("changes and stuff", r.Comment);
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.004, r.Time.Seconds);
        }
    }
}