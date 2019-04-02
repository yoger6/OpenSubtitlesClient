using System.Linq;
using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;
using OpenSubtitlesClient.Communication.Requests.Subtitles.Data;

namespace OpenSubtitlesClient.Communication.Requests.Subtitles
{
    /// <summary>
    ///     This function can be used to search for subtitle files. There are two ways to call it:
    ///     using video file hashes (more at once allowed): Search the database using video file hashes to get exact matches
    ///     for your video files.
    ///     using IMDb IDs: If method 1 returns no subtitle files, you can use this method to search for subtitle files
    ///     matching given imdbid.
    ///     You'll most probably have to synchronize the subtitles yourself or try more to find a match. If you find one,
    ///     please, contribute by uploading them using UploadSubtitles method.
    ///     When this method is used you don't have to specify moviehash and moviebytesize.
    ///     Some fields (IDSubMovieFile, MovieHash, MovieByteSize, MovieTimeMS) are missing in output when using this method.
    ///     If sublanguageid is empty or contains the string 'all' - search is performed for all languages.
    ///     Also remember you can not combine imdbid and moviehash searches in one call.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class SearchSubtitlesRequest : RequestBase
    {
        public SearchSubtitlesRequest()
        {
        }

        public SearchSubtitlesRequest(Token token, params MovieHashData[] movies)
            : base(
                "SearchSubtitles",
                RequestParameter.Token(token),
                HashInformation(movies))
        {
        }

        private static RequestParameter HashInformation(MovieHashData[] hashData)
        {
            var data = hashData.Select(
                                   x =>
                                       RequestParameterValue.Struct(
                                           RequestParameterValue.Member("sublanguageid", RequestParameterValue.String(x.Languages)),
                                           RequestParameterValue.Member("moviehash", RequestParameterValue.String(x.Hash)),
                                           RequestParameterValue.Member("moviebytesize", RequestParameterValue.Double(x.ByteSize))))
                               .ToArray();

            return RequestParameter.Create(RequestParameterValue.Array(data));
        }
    }
}