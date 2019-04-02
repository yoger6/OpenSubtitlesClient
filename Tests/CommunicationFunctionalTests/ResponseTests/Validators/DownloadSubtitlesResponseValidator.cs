using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class DownloadSubtitlesResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as DownloadSubtitlesResponse;

            var sub = r.Subtitles[0];
            Assert.Equal(1951894257, sub.SubtitleFileIdentifier);
            Assert.Equal("base64-encoded and gzipped subtitle file contents", sub.Content);
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.38, r.Time.Seconds);
        }
    }
}