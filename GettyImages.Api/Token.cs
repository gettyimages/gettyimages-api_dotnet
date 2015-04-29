using System;

namespace GettyImages.Api
{
    public class Token
    {
        internal Token()
        {
        }

        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}