using System.Net;

namespace GettyImages.Connect
{
    public class UnauthorizedException : SdkException
    {
        internal UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
}