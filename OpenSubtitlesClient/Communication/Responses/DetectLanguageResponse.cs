using System.Linq;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class DetectLanguageResponse : ResponseBase
    {
        [XmlIgnore]
        public IdentifiedLanguage[] IdentifiedLanguages => Data
            .Select(x => new IdentifiedLanguage(x.Name, x.GetValue<string>()))
            .ToArray();
    }

    [XmlRoot(RootName)]
    public class DownloadSubtitlesResponse : ResponseBase
    {
        [XmlIgnore]
        public BasicSubtitleInformation[] Subtitles => Array
            .Select(
                x =>
                    new BasicSubtitleInformation(
                        x.Members[0].GetValue<int>(), x.Members[1].GetValue<string>()))
            .ToArray();
    }

    public class BasicSubtitleInformation
    {
        public BasicSubtitleInformation(int subtitleFileIdentifier, string content)
        {
            SubtitleFileIdentifier = subtitleFileIdentifier;
            Content = content;
        }

        public int SubtitleFileIdentifier { get; }
        
        /// <summary>
        /// base64-encoded and gzipped
        /// </summary>
        public string Content { get; }
    }
}