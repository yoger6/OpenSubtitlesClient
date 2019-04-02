using CommunicationFunctionalTests.ContractMembers;
using Moq;
using OpenSubtitlesClient;
using OpenSubtitlesClient.Communication.Requests.Server;
using OpenSubtitlesClient.Communication.Responses;
using Xunit;

namespace CommunicationFunctionalTests
{
    public class SessionTests
    {
        private Mock<IOpenSubtitlesHttpClient> _client;
        private readonly Session _session;
        private readonly Token _sessionToken;

        public SessionTests()
        {
            _sessionToken = new TestToken();
            _client = new Mock<IOpenSubtitlesHttpClient>();
            _client.Setup(x => x.Request<LoginResponse>(It.IsAny<LoginRequest>()))
                   .Returns(new LoginResponseStub(_sessionToken));
            _session = new Session(_client.Object);
        }

        [Fact]
        public void Begin_ShouldSendLoginRequestToReceiveToken()
        {
            _session.Begin();

            _client.Verify(x=>x.Request<LoginResponse>(It.IsAny<LoginRequest>()), Times.Once);
        }

        [Fact]
        public void End_ShouldSendLogoutRequestToTerminateTheSession()
        {
            var expectedToken = new TestToken();


            _session.End();

            _client.Verify(x=>x.Request<LogoutResponse>(It.IsAny<LogoutRequest>()), Times.Once);
        }
    }
}
