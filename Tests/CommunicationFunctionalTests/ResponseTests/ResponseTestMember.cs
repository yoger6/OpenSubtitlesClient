using System;

namespace CommunicationFunctionalTests.ResponseTests
{
    public class ResponseTestMember
    {
        private readonly ResponseValidator _validator;
        public Type ResponseType { get; }

        public ResponseTestMember(Type responseType, ResponseValidator validator)
        {
            _validator = validator;
            ResponseType = responseType;
        }

        public void Validate(object response)
        {
            _validator.Validate(response);
        }
    }
}