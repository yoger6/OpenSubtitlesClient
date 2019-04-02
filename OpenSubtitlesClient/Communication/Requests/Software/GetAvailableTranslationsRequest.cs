using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Software
{
    /// <summary>
    ///     Get available translations for given program.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class GetAvailableTranslationsRequest : RequestBase
    {
        public GetAvailableTranslationsRequest()
        {
        }

        public GetAvailableTranslationsRequest(Token token, string applicationName)
            : base(
                "GetAvailableTranslations",
                RequestParameter.Token(token),
                RequestParameter.Create(RequestParameterValue.String(applicationName)))
        {
        }
    }
}