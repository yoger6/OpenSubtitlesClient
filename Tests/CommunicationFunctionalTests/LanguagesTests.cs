using Communication.Common;
using Xunit;

namespace CommunicationFunctionalTests
{
    public class LanguagesTests
    {
        [Fact]
        public void FormatForSerialization_ShouldProduceTextContainingLanguageAbbreviation()
        {
            const string expected = "eng";
            var languages = new LanguageList(Languages.English);

            var actual = languages.FormatForSerialization();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FormatForSerialization_ShouldCombineMultipleLanguagesSeparatingThemByComma()
        {
            const string expected = "eng,pol";
            var languages = new LanguageList(Languages.English, Languages.Polish);

            var actual = languages.FormatForSerialization();

            Assert.Equal(expected, actual);
        }
    }
}
