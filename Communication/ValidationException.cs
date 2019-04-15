using System;

namespace Communication
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) 
            : base(message)
        {
        }
    }
}