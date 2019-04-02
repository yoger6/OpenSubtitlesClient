using System;
using OpenSubtitlesClient.Communication.Requests;
using OpenSubtitlesClient.Communication.Requests.Movies.Data;

namespace OpenSubtitlesClient.Communication.Responses
{
    public class Language : IEquatable<Languages>, IEquatable<Language>
    {
        private readonly Languages _language;

        public string Name => _language.ToString();

        public string LanguageId { get; }

        public LanguageCode Code { get; }

        public Language(string languageName)
        {
            _language = (Languages) Enum.Parse(typeof(Languages), languageName);
        }

        public Language(string name, string id, string code)
            : this(name)
        {
            LanguageId = id;
            Code = (LanguageCode) Enum.Parse(typeof(LanguageCode), code);
        }

        public bool Equals(Language other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Language) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Language left, Language right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Language left, Language right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Languages other)
        {
            return _language == other;
        }
    }
}