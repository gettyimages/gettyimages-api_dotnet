using System.Net;

namespace GettyImages.Api
{
    public class OverQpsException : SdkException
    {
        internal OverQpsException(string message) : base(message, HttpStatusCode.Forbidden)
        {
        }
    }
}