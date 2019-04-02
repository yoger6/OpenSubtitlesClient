using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    [XmlRoot(RootNodeName)]
    public class TryUploadSubtitlesRequest : RequestBase
    {
        public TryUploadSubtitlesRequest()
        {
        }

        public TryUploadSubtitlesRequest(Token token, params TryUploadSubtitlesRequestData[] data)
            : base(
                "TryUploadSubtitles",
                RequestParameter.Token(token),
                BuildDataParameter(data))
        {
        }

        private static RequestParameter BuildDataParameter(TryUploadSubtitlesRequestData[] data)
        {
            var members = BuildMembersFromData(data).ToArray();
            return RequestParameter.Create(RequestParameterValue.Struct(members));
        }

        private static IEnumerable<RequestParameterValueBase> BuildMembersFromData(TryUploadSubtitlesRequestData[] data)
        {
            return data.Select(
                d => RequestParameterValue.Member(
                    d.Name,
                    RequestParameterValue.Struct(
                        RequestParameterValue.Member("subhash", RequestParameterValue.String(d.SubtitleInformation.Hash)),
                        RequestParameterValue.Member("subfilename", RequestParameterValue.String(d.SubtitleInformation.FileName)),
                        RequestParameterValue.Member("moviehash", RequestParameterValue.String(d.MovieInformation.Hash)),
                        RequestParameterValue.Member("moviebytesize", RequestParameterValue.Double(d.MovieInformation.Size)),
                        RequestParameterValue.Member("moviefps", RequestParameterValue.Double(d.MovieInformation.Fps)),
                        RequestParameterValue.Member("movietimems", RequestParameterValue.Int(d.MovieInformation.Length)),
                        RequestParameterValue.Member("movieframes", RequestParameterValue.Int(d.MovieInformation.Frames)),
                        RequestParameterValue.Member("moviefilename", RequestParameterValue.String(d.MovieInformation.FileName))
                    )));
        }
    }
}