using System.Xml.Serialization;
using Communication;
using Communication.Common;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Server
{
    /// <summary>
    ///     Returns list of supported subtitle languages.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class GetSubLanguagesRequest : RequestBase
    {
        public GetSubLanguagesRequest()
        {
        }

        public GetSubLanguagesRequest(LanguageCode language)
            : base(
                "GetSubLanguages",
                RequestParameter.Create(RequestParameterValue.String(language.ToString())))
        {
        }
    }
}