using System;

namespace OpenSubtitlesClient.Communication.Requests
{
    internal class RequestDeserializationException : NotSupportedException
    {
        public RequestDeserializationException()
            : base("Requests are not meant to be deserialized.")
        {
        }
    }
}