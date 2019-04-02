using System.Xml.Serialization;
using OpenSubtitlesClient.Validation;

namespace OpenSubtitlesClient.Communication.Serialization.Parameters
{
    public class Method
    {
        public Method()
        {
        }

        public Method(string name)
        {
            Ensure.NotNullOrEmpty(name);
            Name = name;
        }

        [XmlText]
        public string Name { get; set; }
    }
}