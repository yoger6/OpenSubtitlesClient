using System.Collections.Generic;
using Communication;
using Communication.Common;
using Communication.DataSource;
using Communication.Events;
using Communication.Subtitles;
using Moq;
using Xunit;

namespace CommunicationTests
{
    public class SubtitlesUploadCommandTests
    {
        private readonly Mock<IEventHub> _hubMock;
        private readonly Mock<IOpenSubtitlesClient> _clientMock;
        private readonly Mock<IRequestFactory> _requestFactoryMock;

        public SubtitlesUploadCommandTests()
        {
            _hubMock = new Mock<IEventHub>();
            _clientMock = new Mock<IOpenSubtitlesClient>();
            _requestFactoryMock = new Mock<IRequestFactory>();
        }

        [Fact]
        public void ShouldCreateRequestBasedOnGivenParameters()
        {
            // given
            const string imdbId = "123";
            const LanguageCode language = LanguageCode.en;
            const string movieFileName = "bob.mov";
            const string movieKnownAs = "story of bob";
            const string comment = "private";
            const string token = "token";
            var file1 =  new SubtitleFile();
            var file2 = new SubtitleFile();

            var command = new SubtitlesUploadCommand(imdbId, language, movieFileName, movieKnownAs, comment, token);
            command.AddSubtitles(file1);
            command.AddSubtitles(file2);

            // when
            ExecuteCommand(command);

            // then
            _requestFactoryMock.Verify(x => x.CreateUploadSubtitlesRequest(
                imdbId, language, movieFileName, movieKnownAs, comment,
                It.Is<IList<SubtitleFile>>(y => y.Contains(file1) && y.Contains(file2) && y.Count == 2), token),
                Times.Once);
        }

        [Fact]
        public void ShouldSendTheRequestThroughTheClient()
        {
            // given
            var request = new UploadSubtitlesRawRequest();
            var command = GetCommandAndSetupRequest(request);

            // when
            ExecuteCommand(command);

            // then
            _clientMock.Verify(x=>x.Send(request), Times.Once);
        }

        [Fact]
        public void ShouldRaiseSubtitlesUploadedEvent_WhenCommandSucceeds()
        {
            // given
            var command = GetCommandAndSetupRequest(new UploadSubtitlesRawRequest());

            // when
            ExecuteCommand(command);

            // then
            _hubMock.Verify(x=>x.Publish(It.IsAny<SubtitlesUploaded>()), Times.Once);
        }

        [Fact]
        public void ShouldRaiseSubtitlesNotUploadedEvent_WhenCommunicationFails()
        {
            // given
            const string failureReason = "Not success at all.";
            var request = new UploadSubtitlesRawRequest();
            var command = GetCommandAndSetupRequest(request);

            _clientMock.Setup(x => x.Send(request)).Throws(new CommunicationException(failureReason));

            // when
            ExecuteCommand(command);

            // then
            _hubMock.Verify(x=>x.Publish(It.Is<SubtitlesNotUploaded>(y=>y.Reason == failureReason)), Times.Once);
        }

        [Fact]
        public void ShouldRaiseSubtitlesNotUploadedEvent_WhenValidationFails()
        {
            // given
            const string failureReason = "It's definitely invalid.";
            var request = new UploadSubtitlesRawRequest();
            var command = GetCommandAndSetupRequest(request);

            _requestFactoryMock.Setup(x => x.CreateUploadSubtitlesRequest(
                    It.IsAny<string>(), It.IsAny<LanguageCode>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IList<SubtitleFile>>(), It.IsAny<string>()))
                .Throws(new ValidationException(failureReason));

            // when
            ExecuteCommand(command);

            // then
            _hubMock.Verify(x=>x.Publish(It.Is<SubtitlesNotUploaded>(y=>y.Reason == failureReason)));
        }

        private SubtitlesUploadCommand GetCommandAndSetupRequest(UploadSubtitlesRawRequest request)
        {
            const string id = "123";
            const LanguageCode code = LanguageCode.aa;
            const string placeholder = "asd";
            _requestFactoryMock.Setup(x =>
                    x.CreateUploadSubtitlesRequest(id, code, placeholder, placeholder, placeholder, It.IsAny<IList<SubtitleFile>>(),
                        placeholder))
                .Returns(request);

            return new SubtitlesUploadCommand(id, code, placeholder, placeholder, placeholder, placeholder);
        }

        private void ExecuteCommand(SubtitlesUploadCommand command)
        {
            command.Execute(_hubMock.Object, _clientMock.Object, _requestFactoryMock.Object);
        }
    }
}
