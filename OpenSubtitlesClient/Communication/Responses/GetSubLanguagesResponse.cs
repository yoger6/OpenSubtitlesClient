using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class GetSubLanguagesResponse : ResponseBase
    {
        [XmlIgnore]
        public Language[] SupportedLanguages => ParseLanguages().ToArray();

        private IEnumerable<Language> ParseLanguages()
        {
            foreach (var s in Array)
            {
                var name = s.Members.Single(x => x.Name == "LanguageName").GetValue<string>();
                var id = s.Members.Single(x => x.Name == "SubLanguageID").GetValue<string>();
                var code = s.Members.Single(x => x.Name == "ISO639").GetValue<string>();
                yield return new Language(name, id, code);
            }
        }
    }
}