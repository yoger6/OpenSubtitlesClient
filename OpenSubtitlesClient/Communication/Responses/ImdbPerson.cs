namespace OpenSubtitlesClient.Communication.Responses
{
    public class ImdbPerson
    {
        public ImdbPerson(string id, string name)
        {
            Id = int.Parse(id.Substring(1));
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}