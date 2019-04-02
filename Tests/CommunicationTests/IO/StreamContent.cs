using System.IO;
using FluentAssertions;

namespace CommunicationTests.IO
{
    public static class StreamContent
    {
        public static void AreEqual(Stream first, Stream second)
        {
            var readerOfExpected = new StreamReader(first);
            var readerOfActual = new StreamReader(second);

            var firstContent = readerOfExpected.ReadToEnd();
            var secondContent = readerOfActual.ReadToEnd();

            secondContent.Should().BeEquivalentTo(firstContent);
        }
    }
}
