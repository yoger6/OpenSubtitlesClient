using OpenSubtitlesClient;
using OpenSubtitlesClient.Communication.Responses;
using OpenSubtitlesClient.Communication.Responses.Parameters;

namespace CommunicationFunctionalTests.ContractMembers
{
    internal class LoginResponseStub : LoginResponse
    {
        public LoginResponseStub(Token tokenToReceive)
        {
            Parameters = new ResponseParameters
            {
                Parameter = new ResponseParameter
                {
                    Value = new ResponseParameterValue
                    {
                        Struct = new ResponseStructParameterValue()
                        {
                            //new ResponseMember {Name = Token}, 
                        }
                    }
                }
            };
        }
    }
}
