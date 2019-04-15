using System.Collections.Generic;
using System.Linq;
using Communication.Subtitles;

namespace Communication.DataSource
{
    internal class TryUploadSubtitlesRequestBuilder
    {
        private readonly TryUploadSubtitlesRawRequest _request;
        private readonly IList<TryUploadSubtitlesRawRequest.ParamValueMember> _content;

        public TryUploadSubtitlesRequestBuilder()
        {
            _request = new TryUploadSubtitlesRawRequest
            {
                methodName = "TryUploadSubtitles",
                @params = new TryUploadSubtitlesRawRequest.Param[2]
            };
            _content = new List<TryUploadSubtitlesRawRequest.ParamValueMember>();
        }
        
        public void AddToken(string token)
        {
            var tokenParameter = new TryUploadSubtitlesRawRequest.Param()
            {
                value = new TryUploadSubtitlesRawRequest.ParamValue
                {
                    @string = token
                }
            };

            _request.@params[0] = tokenParameter;
        }

        public void AddFiles(IList<SubtitleFile> files)
        {
            foreach (var file in files)
            {
                var fileInfo = new TryUploadSubtitlesRawRequest.ParamValueMember()
                    {
                        name = file.Name,
                        value = new TryUploadSubtitlesRawRequest.ParamValueMemberValue
                        {
                            @struct = new[]
                            {
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "subhash",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        @string = file.SubtitleInformation.Hash
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "subfilename",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        @string = file.SubtitleInformation.FileName
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "moviehash",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        @string = file.MovieInformation.Hash
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "moviebytesize",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        doubleSpecified = true,
                                        @double = (decimal) file.MovieInformation.Size
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "moviefps",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        doubleSpecified = true,
                                        @double = (decimal) file.MovieInformation.Fps
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "movietimems",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        intSpecified = true,
                                        @int = (uint) file.MovieInformation.Length
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "movieframes",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        intSpecified = true,
                                        @int = (uint) file.MovieInformation.Frames
                                    }
                                },
                                new TryUploadSubtitlesRawRequest.ParamValueMemberValueMember
                                {
                                    name = "moviefilename",
                                    value = new TryUploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                    {
                                        @string = file.MovieInformation.FileName
                                    }
                                }
                            }
                        }
                    };

                _content.Add(fileInfo);
            }
        }

        public TryUploadSubtitlesRawRequest Build()
        {
            var subtitlesParam = new TryUploadSubtitlesRawRequest.Param()
            {
                value = new TryUploadSubtitlesRawRequest.ParamValue
                {
                    @struct = _content.ToArray()
                }
            };

            _request.@params[1] = subtitlesParam;

            return _request;
        }
    }

    internal class SubtitleScore
    {
        public uint SubtitleId { get; }
        public uint Score { get; }

        public SubtitleScore(uint subtitleId, uint score)
        {
            SubtitleId = subtitleId;
            Score = score;
        }
    }
}