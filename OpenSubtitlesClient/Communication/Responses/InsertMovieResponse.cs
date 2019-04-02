using System.Xml.Serialization;

namespace OpenSubtitlesClient.Communication.Responses
{
    [XmlRoot(RootName)]
    public class InsertMovieResponse : ResponseBase
    {
        public int MovieId => int.Parse(GetMember<string>("id"));
    }
}