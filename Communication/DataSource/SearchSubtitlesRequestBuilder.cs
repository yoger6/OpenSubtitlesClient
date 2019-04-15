using System.Collections.Generic;
using Communication.Common;

namespace Communication.DataSource
{
    internal class SearchSubtitlesRequestBuilder
    {
        private readonly SearchSubtitlesRawRequest _request;

        public SearchSubtitlesRequestBuilder()
        {
            _request = new SearchSubtitlesRawRequest
            {
                methodName = "SearchSubtitles",
                @params = new SearchSubtitlesRawRequest.Param[2]
            };
        }

        public void AddToken(string token)
        {
            var tokenParameter = new SearchSubtitlesRawRequest.Param()
            {
                value = new SearchSubtitlesRawRequest.ParamValue
                {
                    @string = token
                }
            };

            _request.@params[0] = tokenParameter;
        }



        public SearchSubtitlesRawRequest Build()
        {
            return _request;
        }

        public void AddMovies(IEnumerable<MovieHashData> movies)
        {
            var movieList = new List<SearchSubtitlesRawRequest.ParamValueArrayValue>();

            foreach (var movie in movies)
            {
                movieList.Add(
                    new SearchSubtitlesRawRequest.ParamValueArrayValue
                {
                    @struct = new []
                    {
                        new SearchSubtitlesRawRequest.ParamValueArrayValueMember
                        {
                            name = "sublanguageid",
                            value = new SearchSubtitlesRawRequest.ParamValueArrayValueMemberValue
                            {
                                @string = movie.Languages
                            }
                        },
                        new SearchSubtitlesRawRequest.ParamValueArrayValueMember
                        {
                            name = "moviehash",
                            value = new SearchSubtitlesRawRequest.ParamValueArrayValueMemberValue
                            {
                                @string = movie.Hash
                            }
                        },new SearchSubtitlesRawRequest.ParamValueArrayValueMember
                        {
                            name = "moviebytesize",
                            value = new SearchSubtitlesRawRequest.ParamValueArrayValueMemberValue
                            {
                                doubleSpecified = true,
                                @double = movie.ByteSize
                            }
                        }
                    }
                });
            }

            _request.@params[1] = new SearchSubtitlesRawRequest.Param
            {
             value = new SearchSubtitlesRawRequest.ParamValue
             {
                 array = new SearchSubtitlesRawRequest.ParamValueArray
                 {
                     data = movieList.ToArray()
                 }
             }
            };
        }
    }
}