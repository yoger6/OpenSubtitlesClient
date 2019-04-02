using System;

namespace OpenSubtitlesClient.Communication.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}