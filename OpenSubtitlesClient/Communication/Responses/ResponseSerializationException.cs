using System;

namespace OpenSubtitlesClient.Communication.Responses
{
    internal class ResponseSerializationException : NotSupportedException
    {
        public ResponseSerializationException()
            : base("Responses are not meant to be serialized.")
        {
        }
    }
}