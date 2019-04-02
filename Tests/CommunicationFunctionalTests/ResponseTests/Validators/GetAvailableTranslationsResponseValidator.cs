using System;
using System.Net;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests.ResponseTests.Validators
{
    internal class GetAvailableTranslationsResponseValidator : ResponseValidator
    {
        public override void Validate(object response)
        {
            var r = response as GetAvailableTranslationsResponse;
            var t = r.Translations[0];

            Assert.Equal(new DateTime(2007, 10, 19, 12, 44, 0), t.CreatedOn);
            Assert.Equal(266, t.NumberOfEntries);
            Assert.Equal(HttpStatusCode.OK, r.Status.Code);
            Assert.Equal(0.006, r.Time.Seconds);
        }
    }
}