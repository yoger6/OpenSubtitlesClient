using System.Linq;
using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class CheckSubHashResponse : ResponseBase
    {
        [XmlIgnore]
        public SubtitleHash[] Hashes => Data
            .Select(x => new SubtitleHash(x.GetValue<string>(), x.Name))
            .ToArray();
    }
}