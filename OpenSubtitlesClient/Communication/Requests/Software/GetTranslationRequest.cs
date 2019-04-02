using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Software
{
    /// <summary>
    ///     This function is used to provide multi-language support for client applications in a single environment.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class GetTranslationRequest : RequestBase
    {
        public GetTranslationRequest()
        {
        }

        public GetTranslationRequest(Token token, string programName, TranslationFormat format, LanguageCode language)
            : base(
                "GetTranslation",
                RequestParameter.Token(token),
                RequestParameter.Create(RequestParameterValue.String(language.ToString())),
                RequestParameter.Create(RequestParameterValue.String(format.ToString())),
                RequestParameter.Create(RequestParameterValue.String(programName)))
        {
        }
    }
}