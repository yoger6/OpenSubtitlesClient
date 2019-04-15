using System.Collections.Generic;
using System.Linq;
using Communication.Common;
using Communication.Subtitles;

namespace Communication.DataSource
{
    public class OpenSubtitlesRequestFactory : IRequestFactory
    {
        public UploadSubtitlesRawRequest CreateUploadSubtitlesRequest(string imdbId,
            LanguageCode language,
            string movieFileName,
            string movieKnownAs,
            string comment,
            IList<SubtitleFile> files, 
            string token)
        {
            var builder = new UploadSubtitlesRequestBuilder();

            builder.AddToken(token);
            builder.AddInfo(imdbId, language, movieFileName, movieKnownAs, comment);
            builder.AddFiles(files);

            return builder.Build();
        }

        public TryUploadSubtitlesRawRequest CreateTryUploadSubtitlesRequest(IList<SubtitleFile> subtitles, string token)
        {
            var builder = new TryUploadSubtitlesRequestBuilder();

            builder.AddToken(token);
            builder.AddFiles(subtitles);

            return builder.Build();
        }

        public SubtitlesVoteRawRequest CreateSubtitlesVoteRequest(uint subtitleId, uint score, string token)
        {
            var builder = new SubtitlesVoteRequestBuilder();

            builder.AddToken(token);
            builder.SetScore(new SubtitleScore(subtitleId, score));

            return builder.Build();
        }

        public ServerInfoRawRequest CreateServerInfoRequest()
        {
            return new ServerInfoRawRequest
            {
                methodName = "ServerInfo",
                @params =  new object()
            };
        }

        public SearchSubtitlesRawRequest CreateSearchSubtitlesRequest(string token, IEnumerable<MovieHashData> movies)
        {
            var builder = new SearchSubtitlesRequestBuilder();

            builder.AddToken(token);
            builder.AddMovies(movies);

            return builder.Build();
        }

        public SearchMoviesOnIMDBRawRequest CreateSearchMoviesOnImdbRequest(string name, string token)
        {
            return new SearchMoviesOnIMDBRawRequest
            {
                methodName = "SearchMoviesOnIMDB",
                @params = new[]
                {
                    new SearchMoviesOnIMDBRawRequest.Param
                    {
                        value = new SearchMoviesOnIMDBRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new SearchMoviesOnIMDBRawRequest.Param
                    {
                        value = new SearchMoviesOnIMDBRawRequest.ParamValue
                        {
                            @string = name
                        }
                    },
                }
            };
        }

        public ReportWrongMovieHashRawRequest CreateReportWrongMovieHashRequest(uint subtitleId, string token)
        {
            return new ReportWrongMovieHashRawRequest
            {
                methodName = "ReportWrongMovieHash",
                @params = new[]
                {
                    new ReportWrongMovieHashRawRequest.Param
                    {
                        value = new ReportWrongMovieHashRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new ReportWrongMovieHashRawRequest.Param
                    {
                        value = new ReportWrongMovieHashRawRequest.ParamValue
                        {
                            intSpecified = true,
                            @int = subtitleId
                        }
                    },
                }
            };
        }

        public NoOperationRawRequest CreateNoOperationRequest(string token)
        {
            return new NoOperationRawRequest
            {
                methodName = "NoOperation",
                @params = new NoOperationRawRequest.Params
                {
                    param = new NoOperationRawRequest.ParamsParam
                    {
                        value = new NoOperationRawRequest.ParamsParamValue
                        {
                            @string = token
                        }
                    }
                }
            };
        }

        public LogoutRawRequest CreateLogoutRequest(string token)
        {
            return new LogoutRawRequest
            {
                methodName = "LogOut",
                @params = new LogoutRawRequest.Params
                {
                    param = new LogoutRawRequest.ParamsParam
                    {
                        value = new LogoutRawRequest.ParamsParamValue
                        {
                            @string = token
                        }
                    }
                }
            };
        }

        public LoginRawRequest CreateLoginRequest(string user, string password, LanguageCode language, string agent)
        {
            return new LoginRawRequest
            {
                methodName = "LogIn",
                @params = new []
                {
                    new LoginRawRequest.Param
                    {
                        value = new LoginRawRequest.ParamValue
                        {
                            @string = user
                        }
                    },
                    new LoginRawRequest.Param
                    {
                        value = new LoginRawRequest.ParamValue
                        {
                            @string = password
                        }
                    },
                    new LoginRawRequest.Param
                    {
                        value = new LoginRawRequest.ParamValue
                        {
                            @string = language.ToString()
                        }
                    },
                    new LoginRawRequest.Param
                    {
                        value = new LoginRawRequest.ParamValue
                        {
                            @string = agent
                        }
                    },
                }
            };
        }

        public InsertMovieRawRequest CreateInsertMovieRequest(string title, int year, string token)
        {
            return new InsertMovieRawRequest
            {
                methodName = "InsertMovie",
                @params = new []
                {
                    new InsertMovieRawRequest.Param
                    {
                        value = new InsertMovieRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new InsertMovieRawRequest.Param
                    {
                        value = new InsertMovieRawRequest.ParamValue
                        {
                            @struct = new []
                            {
                                new InsertMovieRawRequest.ParamValueMember
                                {
                                    name = "moviename",
                                    value = new InsertMovieRawRequest.ParamValueMemberValue
                                    {
                                        @string = title
                                    }
                                },
                                new InsertMovieRawRequest.ParamValueMember
                                {
                                    name = "movieyear",
                                    value = new InsertMovieRawRequest.ParamValueMemberValue
                                    {
                                        @string = year.ToString()
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        public GetTranslationRawRequest CreateGetTranslationRequest(LanguageCode language, TranslationFormat format, string applicationName, string token)
        {
            return new GetTranslationRawRequest
            {
                methodName = "GetTranslation",
                @params = new[]
                {
                    new GetTranslationRawRequest.Param
                    {
                        value = new GetTranslationRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new GetTranslationRawRequest.Param
                    {
                        value = new GetTranslationRawRequest.ParamValue
                        {
                            @string = language.ToString()
                        }
                    },
                    new GetTranslationRawRequest.Param
                    {
                        value = new GetTranslationRawRequest.ParamValue
                        {
                            @string = format.ToString()
                        }
                    },
                    new GetTranslationRawRequest.Param
                    {
                        value = new GetTranslationRawRequest.ParamValue
                        {
                            @string = applicationName
                        }
                    }
                }
            };
        }

        public GetSubLanguagesRawRequest CreateGetSubLanguagesRequest(LanguageCode language)
        {
            return new GetSubLanguagesRawRequest
            {
                methodName = "GetSubLanguages",
                @params = new GetSubLanguagesRawRequest.Params
                {
                    param = new GetSubLanguagesRawRequest.ParamsParam
                    {
                        value = new GetSubLanguagesRawRequest.ParamsParamValue
                        {
                            @string = language.ToString()
                        }
                    }
                }
            };
        }

        public GetIMDBMovieDetailsRawRequest CreateGetImdbMovieDetailsRequest(string imdbMovieId, string token)
        {
            return new GetIMDBMovieDetailsRawRequest
            {
                methodName = "GetIMDBMovieDetails",
                @params = new[]
                {
                    new GetIMDBMovieDetailsRawRequest.Param
                    {
                        value = new GetIMDBMovieDetailsRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new GetIMDBMovieDetailsRawRequest.Param
                    {
                        value = new GetIMDBMovieDetailsRawRequest.ParamValue
                        {
                            @string = imdbMovieId
                        }
                    }
                }
            };
        }

        public GetAvailableTranslationsRawRequest CreateGetAvailableTranslationsRequest(string applicationName, string token)
        {
            return new GetAvailableTranslationsRawRequest
            {
                methodName = "GetAvailableTranslations",
                @params = new []
                {
                    new GetAvailableTranslationsRawRequest.Param
                    {
                        value = new GetAvailableTranslationsRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new GetAvailableTranslationsRawRequest.Param
                    {
                        value = new GetAvailableTranslationsRawRequest.ParamValue
                        {
                            @string = applicationName
                        }
                    }
                }
            };
        }

        public DownloadSubtitlesRawRequest CreateDownloadSubtitlesRequest(uint[] subtitleIds, string token)
        {
            var request = new DownloadSubtitlesRawRequest();

            request.methodName = "DownloadSubtitles";

            request.@params = new[]
            {
                new DownloadSubtitlesRawRequest.Param
                {
                    value = new DownloadSubtitlesRawRequest.ParamValue
                    {
                        @string = token
                    }
                },
                new DownloadSubtitlesRawRequest.Param
                {
                    value = new DownloadSubtitlesRawRequest.ParamValue
                    {
                        array = new DownloadSubtitlesRawRequest.ParamValueArray
                        {
                            data = subtitleIds.Select(x=> new DownloadSubtitlesRawRequest.ParamValueArrayValue {@int = x}).ToArray()
                        }
                    }
                }
            };

            return request;
        }

        public DetectLanguageRawRequest CreateDetectLanguageRequest(string[] texts, string token)
        {
            return new DetectLanguageRawRequest
            {
                methodName = "DetectLanguage",
                @params = new[]
                {
                    new DetectLanguageRawRequest.Param
                    {
                        value = new DetectLanguageRawRequest.ParamValue
                        {
                            @string = token
                        }
                    },
                    new DetectLanguageRawRequest.Param
                    {
                        value = new DetectLanguageRawRequest.ParamValue
                        {
                            array = new DetectLanguageRawRequest.ParamValueArray
                            {
                                data = texts.Select(x => new DetectLanguageRawRequest.ParamValueArrayValue { @string = x }).ToArray()
                            }
                        }
                    }
                }
            };
        }
    }
}
