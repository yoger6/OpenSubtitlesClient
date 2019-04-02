using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class LoginResponse : ResponseBase
    {
        public Token Token => new Token(GetMember<string>("token"));
    }
}