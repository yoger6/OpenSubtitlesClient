using System;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Requests.Server;
using OpenSubtitlesClient.Communication.Responses;

namespace OpenSubtitlesClient
{
    public class Session : IDisposable
    {
        private readonly IOpenSubtitlesHttpClient _client;

        public Session(IOpenSubtitlesHttpClient client)
        {
            _client = client;
        }

        public void Begin()
        {
            _client.Request<LoginResponse>(new LoginRequest());
        }

        public void Dispose()
        {
        }

        public void End()
        {
            _client.Request<LogoutResponse>(new LogoutRequest());
        }
    }

    public interface IOpenSubtitlesHttpClient
    {
        T Request<T>(RequestBase request);
    }
}
