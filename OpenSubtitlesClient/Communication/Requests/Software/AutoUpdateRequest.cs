using System.Xml.Serialization;
using OpenSubtitlesClient.Communication.Requests.Parameters;

namespace OpenSubtitlesClient.Communication.Requests.Software
{
    /// <summary>
    /// Checks for the latest version of application and returns download links and changelog.
    /// </summary>
    [XmlRoot(RootNodeName)]
    public class AutoUpdateRequest : RequestBase
    {
        public AutoUpdateRequest()
        {
        }

        /// <param name="applicationName">Name of application to check.</param>
        public AutoUpdateRequest(string applicationName)
            : base(
                "AutoUpdate",
                RequestParameter.Create(RequestParameterValue.String(applicationName)))
        {
        }
    }
}