using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class GetTranslationResponse : ResponseBase
    {
        public string Translation => GetMember<string>("data");
    }
}