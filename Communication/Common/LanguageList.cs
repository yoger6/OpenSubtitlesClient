using System.Linq;

namespace Communication.Common
{
    public class LanguageList
    {
        private readonly Languages[] _languages;

        public LanguageList()
        {
        }

        public LanguageList(params Languages[] languages)
        {
            _languages = languages;
        }

        public string FormatForSerialization()
        {
            const string separator = ",";

            return string.Join(separator, _languages.Select(x => x.ToString().Substring(0, 3).ToLowerInvariant()));
        }
    }
}