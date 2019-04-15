using System;

namespace Communication
{
    public class CommunicationException : Exception
    {
        public CommunicationException(string message) 
            : base(message)
        {
        }
    }
}