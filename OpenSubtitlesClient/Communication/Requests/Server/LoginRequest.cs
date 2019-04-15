using System.Xml.Serialization;
using Communication;
using Communication.Common;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Server
{
    [XmlRoot(RootNodeName)]
    public class LoginRequest : RequestBase
    {
        public LoginRequest()
        {
        }

        public LoginRequest(string userAgent, LanguageCode language, string login, string password)
            : base(
                "LogIn",
                RequestParameter.Create(RequestParameterValue.String(login)),
                RequestParameter.Create(RequestParameterValue.String(password)),
                RequestParameter.Create(RequestParameterValue.String(language.ToString())),
                RequestParameter.Create(RequestParameterValue.String(userAgent)))
        {
        }
    }
}