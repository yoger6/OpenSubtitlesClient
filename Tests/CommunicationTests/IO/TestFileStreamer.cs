using System.IO;

namespace CommunicationTests.IO
{
    public static class TestFileStreamer
    {
        /// <summary>
        /// Opens file stream for reading.
        /// </summary>
        /// <param name="relativeFileLocation">File location that is relative to the executing assembly.</param>
        public static Stream StreamFileContent(string relativeFileLocation)
        {
            return File.OpenRead(relativeFileLocation);
        }
    }
}