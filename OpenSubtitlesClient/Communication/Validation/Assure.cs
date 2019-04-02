using System.Collections.Generic;
using System.Linq;

namespace OpenSubtitlesClient.Communication.Validation
{
    public static class Assure
    {
        public static void NotNull(object @object, string name)
        {
            if (@object == null)
            {
                throw new ValidationException($"{name} must not be null.");
            }
        }

        public static void NotEmpty(string text, string name)
        {
            if (text.Trim() == string.Empty)
            {
                throw new ValidationException($"{name} must not be an empty text.");
            }
        }

        public static void NotEmpty<T>(IEnumerable<T> items, string name)
        {
            if (!items.Any())
            {
                throw new ValidationException($"{name} must not be an empty.");
            }
        }

        public static void HasLength(string text, int length, string name)
        {
            if (text.Trim().Length < length)
            {
                throw new ValidationException($"The text {text}, given as {name} was expected to be at least {length} characters.");
            }
        }

        public static void GreaterThanZero(int number, string name)
        {
            if (number < 1)
            {
                throw new ValidationException($"{name} must be greater than zero, but it was: {number}");
            }
        }
    }

    public static class AssureAll
    {
        public static void HaveLength(string[] strings, int length, string name)
        {
            var elementName = $"Element of {name}";
            Assure.NotNull(strings, name);

            foreach (var s in strings)
            {
                Assure.NotNull(s, elementName);
                Assure.HasLength(s, length, elementName);
            }
        }
    }
}