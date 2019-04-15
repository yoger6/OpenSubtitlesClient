namespace Communication.Common
{
    public class MovieInformation
    {
        public string Hash { get; }
        public double Size { get; }
        public double Fps { get; }
        public int Length { get; }
        public int Frames { get; }
        public string FileName { get; }

        /// <param name="hash">Hash code.</param>
        /// <param name="size">File size - byte count.</param>
        /// <param name="fps">Frames per second.</param>
        /// <param name="length">Length in milliseconds.</param>
        /// <param name="frames">Frame count.</param>
        public MovieInformation(string hash, double size, double fps, int length, int frames, string fileName)
        {
            Hash = hash;
            Size = size;
            Fps = fps;
            Length = length;
            Frames = frames;
            FileName = fileName;
        }
    }
}