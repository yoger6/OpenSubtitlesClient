using System;
using System.Linq;
using System.Net;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class ResponseStatus
    {
        public HttpStatusCode Code { get; }

        public ResponseStatus(string status)
        {
            const char separator = ' ';
            Code = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), status.Split(separator).First());
        }
    }
}