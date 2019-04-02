using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class CheckSubHashResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as CheckSubHashResponse;

            VerifyHash(r.Hashes[0], "sub hash 1", "sub 1 id");
            VerifyHash(r.Hashes[1], "sub hash 2", "sub 2 id");
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.207, r.Time.Seconds);
        }

        private static void VerifyHash(SubtitleHash hash, string subHash, string hashId)
        {
            Assert.Equal(subHash, hash.Hash);
            Assert.Equal(hashId, hash.Identifier);
        }
    }
}