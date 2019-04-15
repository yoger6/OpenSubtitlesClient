using System.Collections.Generic;
using System.Linq;
using Communication.Common;
using Communication.Subtitles;

namespace Communication.DataSource
{
    internal class UploadSubtitlesRequestBuilder
    {
        private readonly UploadSubtitlesRawRequest _request;
        private readonly IList<UploadSubtitlesRawRequest.ParamValueMember> _content;

        public UploadSubtitlesRequestBuilder()
        {
            _request = new UploadSubtitlesRawRequest
            {
                methodName = "UploadSubtitles",
                @params = new UploadSubtitlesRawRequest.Param[2]
            };
            _content = new List<UploadSubtitlesRawRequest.ParamValueMember>();
        }

        public void AddToken(string token)
        {
            var tokenParameter = new UploadSubtitlesRawRequest.Param()
            {
                value = new UploadSubtitlesRawRequest.ParamValue
                {
                    @string = token
                }
            };

            _request.@params[0] = tokenParameter;
        }

        public void AddInfo(string imdbId, LanguageCode language, string movieFileName, string movieKnownAs, string comment)
        {
            var info = new UploadSubtitlesRawRequest.ParamValueMember
            {
                name = "baseinfo",
                value = new UploadSubtitlesRawRequest.ParamValueMemberValue
                {
                    @struct = new[]
                    {
                        new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                        {
                            name = "idmovieimdb",
                            value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue()
                            {
                                @string = imdbId
                            }
                        },
                        new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                        {
                            name = "sublanguageid",
                            value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue()
                            {
                                @string = language.ToString()
                            }
                        },
                        new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                        {
                            name = "moviereleasename",
                            value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue()
                            {
                                @string = movieFileName
                            }
                        },
                        new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                        {
                            name = "movieaka",
                            value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue()
                            {
                                @string = movieKnownAs
                            }
                        },
                        new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                        {
                            name = "subauthorcomment",
                            value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue()
                            {
                                @string = comment
                            }
                        }
                    }
                }
            };

            _content.Add(info);
        }

        public void AddFiles(IList<SubtitleFile> files)
        {
            foreach (var file in files)
            {
                var fileInfo = new UploadSubtitlesRawRequest.ParamValueMember
                {
                    name = file.Name,
                    value = new UploadSubtitlesRawRequest.ParamValueMemberValue
                    {
                        @struct = new[]
                        {
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "subhash",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    @string = file.SubtitleInformation.Hash
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "subfilename",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    @string = file.SubtitleInformation.FileName
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "moviehash",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    @string = file.MovieInformation.Hash
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "moviebytesize",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    doubleSpecified = true,
                                    @double = (decimal) file.MovieInformation.Size
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "moviefps",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    doubleSpecified = true,
                                    @double = (decimal) file.MovieInformation.Fps
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "movietimems",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    intSpecified = true,
                                    @int = (uint) file.MovieInformation.Length
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "movieframes",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    intSpecified = true,
                                    @int = (uint) file.MovieInformation.Frames
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "moviefilename",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    @string = file.MovieInformation.FileName
                                }
                            },
                            new UploadSubtitlesRawRequest.ParamValueMemberValueMember
                            {
                                name = "subcontent",
                                value = new UploadSubtitlesRawRequest.ParamValueMemberValueMemberValue
                                {
                                    @string = file.SubtitleInformation.Content //TODO:Gzip and encode it!
                                }
                            }
                        }
                    }
                };

                _content.Add(fileInfo);
            }
        }

        public UploadSubtitlesRawRequest Build()
        {
            var subtitlesParam = new UploadSubtitlesRawRequest.Param()
            {
                value = new UploadSubtitlesRawRequest.ParamValue
                {
                    @struct = _content.ToArray()
                }
            };
            _request.@params[1] = subtitlesParam;

            return _request;
        }
    }
}