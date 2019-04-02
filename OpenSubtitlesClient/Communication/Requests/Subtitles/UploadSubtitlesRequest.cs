using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     This function takes care of uploading subtitles to OSDb server and should be called after TryUploadSubtitles().
    ///     Most of the information is the same as in TryUploadSubtitles(), the important part is subcontent.
    ///     It should be gzipped(without header) and then base64-encoded contents of the subtitle file.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class UploadSubtitlesRequest : RequestBase
    {
        public UploadSubtitlesRequest()
        {
        }

        public UploadSubtitlesRequest(Token token, UploadSubtitlesRequestData data)
            : base(
                "UploadSubtitles",
                RequestParameter.Token(token),
                BuildDataParameter(data))
        {
        }

        private static RequestParameter BuildDataParameter(UploadSubtitlesRequestData data)
        {
            var members = BuildMembersFromData(data).ToArray();
            return RequestParameter.Create(RequestParameterValue.Struct(members));
        }

        private static IEnumerable<RequestParameterValueBase> BuildMembersFromData(UploadSubtitlesRequestData d)
        {
            yield return RequestParameterValue.Member(
                "baseinfo",
                RequestParameterValue.Struct(
                    RequestParameterValue.Member("idmovieimdb", RequestParameterValue.String(d.General.ImdbId)),
                    RequestParameterValue.Member("sublanguageid", RequestParameterValue.String(d.General.SubtitleLanguage.ToString())),
                    RequestParameterValue.Member("moviereleasename", RequestParameterValue.String(d.General.MovieFileName)),
                    RequestParameterValue.Member("movieaka", RequestParameterValue.String(d.General.MovieAlsoKnownAs)),
                    RequestParameterValue.Member("subauthorcomment", RequestParameterValue.String(d.General.Comment))));

            foreach (var s in d.SubtitleFiles)
            {
                yield return RequestParameterValue.Member(
                    s.Name,
                    RequestParameterValue.Struct(
                        RequestParameterValue.Member("subhash", RequestParameterValue.String(s.SubtitleInformation.Hash)),
                        RequestParameterValue.Member("subfilename", RequestParameterValue.String(s.SubtitleInformation.FileName)),
                        RequestParameterValue.Member("moviehash", RequestParameterValue.String(s.MovieInformation.Hash)),
                        RequestParameterValue.Member("moviebytesize", RequestParameterValue.Double(s.MovieInformation.Size)),
                        RequestParameterValue.Member("moviefps", RequestParameterValue.Double(s.MovieInformation.Fps)),
                        RequestParameterValue.Member("movietimems", RequestParameterValue.Int(s.MovieInformation.Length)),
                        RequestParameterValue.Member("movieframes", RequestParameterValue.Int(s.MovieInformation.Frames)),
                        RequestParameterValue.Member("moviefilename", RequestParameterValue.String(s.MovieInformation.FileName)),
                        RequestParameterValue.Member("subcontent", RequestParameterValue.String(s.SubtitleInformation.Content))));
            }
        }
    }
}