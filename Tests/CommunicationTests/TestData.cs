using System;

namespace CommunicationTests
{
    internal class TestData
    {
        public TestData(Type requestType, object request)
        {
            RequestType = requestType;
            Request = request;
        }

        public Type RequestType { get; }

        public object Request { get; }
    }
}