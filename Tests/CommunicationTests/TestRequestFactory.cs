namespace CommunicationTests
{
    internal class TestRequestFactory
    {
        public static TestData[] GetTestData()
        {
            return new[]
            {
                new TestData(typeof(AddCommentRawRequest), GetAddCommentRequest()),
                new TestData(typeof(AutoUpdateRawRequest), GetAutoUpdateRequest()),
                new TestData(typeof(CheckMovieHashRawRequest), GetCheckMovieHashRawRequest()),
            };
        }

        private static CheckMovieHashRawRequest GetCheckMovieHashRawRequest()
        {
            return new CheckMovieHashRawRequest
            {
                methodName = "CheckMovieHash",
                @params = new []
                {
                    new Param ()
                }
            };
        }

        private static AddCommentRawRequest GetAddCommentRequest()
        {
            return new AddCommentRawRequest
            {
                methodName = "AddComment",
                @params = new[]
                {
                    new AddCommentRawRequest.Param
                    {
                        value = new AddCommentRawRequest.ParamValue { @string = "token" }
                    },
                    new AddCommentRawRequest.Param
                    {
                        value = new AddCommentRawRequest.ParamValue
                        {
                            @struct = new[]
                            {
                                new AddCommentRawRequest.ParamValueMember
                                {
                                    name = "idsubtitle",
                                    value = new AddCommentRawRequest.ParamValueMemberValue
                                    {
                                        @int = 1,
                                        intSpecified = true
                                    }
                                },
                                new AddCommentRawRequest.ParamValueMember
                                {
                                    name = "comment",
                                    value = new AddCommentRawRequest.ParamValueMemberValue
                                    {
                                        @string = "actual comment"
                                    }
                                },
                                new AddCommentRawRequest.ParamValueMember
                                {
                                    name = "badsubtitle",
                                    value = new AddCommentRawRequest.ParamValueMemberValue
                                    {
                                        @int = 0,
                                        intSpecified = true
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private static AutoUpdateRawRequest GetAutoUpdateRequest()
        {
            return new AutoUpdateRawRequest
            {
                methodName = "AutoUpdate",
                @params = new AutoUpdateRawRequest.Params
                {
                    param = new AutoUpdateRawRequest.ParamsParam
                    {
                        value =
                            new AutoUpdateRawRequest.ParamsParamValue
                            {
                                @string = "MovieOrganizer"
                            }
                    }
                }
            };
        }
    }
}