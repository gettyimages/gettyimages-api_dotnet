﻿namespace GettyImages.Api.Models
{
    public class OAuthResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
    }
}