using System.Net;

namespace GettyImages.Api
{
    public class UnauthorizedException : SdkException
    {
        internal UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
}