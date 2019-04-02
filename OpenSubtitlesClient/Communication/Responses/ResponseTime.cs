namespace OpenSubtitlesClient.Communication.Responses
{
    public class ResponseTime
    {
        public double Seconds { get; }

        public ResponseTime(double seconds)
        {
            Seconds = seconds;
        }
    }
}