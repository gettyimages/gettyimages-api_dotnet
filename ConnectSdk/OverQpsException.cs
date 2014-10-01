using System.Net;

namespace GettyImages.Connect
{
    public class OverQpsException : SdkException
    {
        internal OverQpsException(string message) : base(message, HttpStatusCode.Forbidden)
        {
        }
    }
}