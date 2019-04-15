namespace Communication.DataSource
{
    internal class SubtitlesVoteRequestBuilder
    {
        private readonly SubtitlesVoteRawRequest _request;

        public SubtitlesVoteRequestBuilder()
        {
            _request = new SubtitlesVoteRawRequest
            {
                methodName = "SubtitlesVote",
                @params = new SubtitlesVoteRawRequest.Param[2]
            };
        }

        public void AddToken(string token)
        {
            var tokenParameter = new SubtitlesVoteRawRequest.Param()
            {
                value = new SubtitlesVoteRawRequest.ParamValue
                {
                    @string = token
                }
            };

            _request.@params[0] = tokenParameter;
        }

        public void SetScore(SubtitleScore score)
        {
            var scoreParameter = new[]
            {
                new SubtitlesVoteRawRequest.ParamValueMember
                {
                    name = "idsubtitle",
                    value = new SubtitlesVoteRawRequest.ParamValueMemberValue
                    {
                        @int = score.SubtitleId
                    }
                },
                new SubtitlesVoteRawRequest.ParamValueMember
                {
                    name = "score",
                    value = new SubtitlesVoteRawRequest.ParamValueMemberValue
                    {
                        @int = score.Score
                    }
                }
            };

            _request.@params[1] = new SubtitlesVoteRawRequest.Param
            {
                value = new SubtitlesVoteRawRequest.ParamValue
                {
                    @struct = scoreParameter
                }
            };
        }

        public SubtitlesVoteRawRequest Build()
        {
            return _request;
        }
    }
}