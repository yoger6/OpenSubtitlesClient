using System.IO;
using System.Reflection;

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
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            return File.OpenRead(Path.Combine(assemblyDirectory, relativeFileLocation));
        }
    }
}