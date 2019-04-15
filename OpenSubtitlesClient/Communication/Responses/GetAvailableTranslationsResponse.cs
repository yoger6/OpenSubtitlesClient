using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Communication;
using Communication.Common;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class GetAvailableTranslationsResponse : ResponseBase
    {
        [XmlIgnore]
        public AvailableTranslation[] Translations => Data
            .Select(
                x => new AvailableTranslation(
                    x.Name,
                    x.GetValue<IList<ResponseMember>>()
                    .Single(y => y.Name == "LastCreated")
                     .GetValue<string>(),
                    x.GetValue<IList<ResponseMember>>()
                    .Single(y => y.Name == "StringsNo")
                     .GetValue<string>()))
            .ToArray();
    }

    public class AvailableTranslation
    {
        public AvailableTranslation(string language, string createdOn, string numberOfEntries)
        {
            Language = (LanguageCode)Enum.Parse(typeof(LanguageCode), language);
            CreatedOn = DateTime.Parse(createdOn);
            NumberOfEntries = int.Parse(numberOfEntries);
        }

        public LanguageCode Language { get; }
        public DateTime CreatedOn { get; }
        public int NumberOfEntries { get; }
    }
}