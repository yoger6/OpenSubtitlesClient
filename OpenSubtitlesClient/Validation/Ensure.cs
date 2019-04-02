using System;

namespace OpenSubtitlesClient.Validation
{
    public class Ensure
    {
        public static void NotNullOrEmpty(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException(nameof(text));
            }
        }
    }
}