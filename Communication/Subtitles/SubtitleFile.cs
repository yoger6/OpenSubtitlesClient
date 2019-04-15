using Communication.Common;

namespace Communication.Subtitles
{
    public class SubtitleFile
    {
        public SubtitleFile()
        {
        }

        public SubtitleFile(string name, SubtitleInformation subtitleInformation, MovieInformation movieInformation)
        {
            Name = name;
            SubtitleInformation = subtitleInformation;
            MovieInformation = movieInformation;
        }

        public string Name { get; }

        public SubtitleInformation SubtitleInformation { get; }

        public MovieInformation MovieInformation { get; }
    }
}