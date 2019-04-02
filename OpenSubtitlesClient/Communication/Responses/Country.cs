using System;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class Country : IEquatable<Countries>, IEquatable<Country>
    {
        private readonly Countries _country;

        public Country(string name)
        {
            _country = (Countries)Enum.Parse(typeof(Countries), name);
        }

        public bool Equals(Country other)
        {
            return other._country == _country;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Country) obj);
        }

        public override int GetHashCode()
        {
            return (int)_country;
        }

        public static bool operator ==(Country left, Country right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Country left, Country right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Countries other)
        {
            return _country == other;
        }
    }
}