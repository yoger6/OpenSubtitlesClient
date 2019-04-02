using System;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class Genre : IEquatable<Genres>, IEquatable<Genre>
    {
        private readonly Genres _genre;
        public Genre(string value)
        {
            if (value == "Sci-Fi")
            {
                _genre = Genres.SciFi;
            }
            else
            {
                _genre = (Genres) Enum.Parse(typeof(Genres), value);
            }
        }

        public bool Equals(Genre other)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Genre) obj);
        }

        public override int GetHashCode()
        {
            return (int) _genre;
        }

        public static bool operator ==(Genre left, Genre right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Genre left, Genre right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Genres other)
        {
            return _genre == other;
        }
    }
}