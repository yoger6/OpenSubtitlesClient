using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Software
{
    /// <summary>
    ///     Given an array of strings data the function will return a structure with detected languages
    ///     for all the strings given as parameters.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class DetectLanguageRequest : RequestBase
    {
        public DetectLanguageRequest()
        {
        }

        public DetectLanguageRequest(Token token, params string[] texts)
            : base(
                "DetectLanguage",
                RequestParameter.Token(token),
                RequestParameter.Strings(texts))
        {
        }
    }
}