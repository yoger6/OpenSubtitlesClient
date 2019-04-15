namespace Communication.Common
{
    public class MovieHashData
    {
        public MovieHashData(LanguageList languages, string hash, long byteSize)
        {
            Languages = languages.FormatForSerialization();
            Hash = hash;
            ByteSize = byteSize;
        }

        public string Languages { get; }

        public string Hash { get; }

        public long ByteSize { get; }
    }
}