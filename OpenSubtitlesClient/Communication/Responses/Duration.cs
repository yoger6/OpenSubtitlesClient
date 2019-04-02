using System;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class Duration
    {
        private readonly TimeSpan _duration;

        public Duration(string minutes)
        {
            var actualMinutes = minutes.Split(' ')[0];
            _duration = TimeSpan.FromMinutes(int.Parse(actualMinutes));
        }

        public int Minutes => (int)_duration.TotalMinutes;
    }
}