using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Handlers;

namespace GettyImages.Api
{
    public class Credentials
    {
        private const string ClientIdKey = "client_id";
        private const string ClientSecretKey = "client_secret";
        private const string UsernameKey = "username";
        private const string PasswordKey = "password";
        private const string ClientCredentialsValue = "client_credentials";
        private const string GrantTypeKey = "grant_type";
        private const string Oauth2TokenPath = "/oauth2/token";
        private const string Refresh = "refresh_token";
        private readonly string _baseUrl;
        private Token _accessToken;


        internal Credentials(string apiKey, string apiSecret, string baseUrl)
        {
            _baseUrl = baseUrl;
            CredentialType = CredentialType.ClientCredentials;
            ApiKey = apiKey;
            ApiSecret = apiSecret;
        }

        internal Credentials(string apiKey, string apiSecret, string refreshToken, string baseUrl)
        {
            _baseUrl = baseUrl;
            CredentialType = CredentialType.RefreshToken;
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            RefreshToken = refreshToken;
        }

        internal Credentials(string apiKey, string apiSecret, string userName, string userPassword, string baseUrl)
        {
            _baseUrl = baseUrl;
            CredentialType = CredentialType.ResourceOwner;
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            UserName = userName;
            UserPassword = userPassword;
        }

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public CredentialType CredentialType { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        internal IEnumerable<KeyValuePair<string, string>> GetCredentialsDictionary()
        {
            var dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(ApiKey))
            {
                dict.Add(ClientIdKey, ApiKey);
            }

            if (!string.IsNullOrEmpty(ApiSecret))
            {
                dict.Add(ClientSecretKey, ApiSecret);
            }

            if (!string.IsNullOrEmpty(UserName))
            {
                dict.Add(UsernameKey, UserName);
            }

            if (!string.IsNullOrEmpty(UserPassword))
            {
                dict.Add(PasswordKey, UserPassword);
            }
            if (!string.IsNullOrEmpty(RefreshToken))
            {
                dict.Add(Refresh, RefreshToken);
            }

            switch (CredentialType)
            {
                case CredentialType.ClientCredentials:
                    dict.Add(GrantTypeKey, ClientCredentialsValue);
                    break;
                case CredentialType.ResourceOwner:
                    dict.Add(GrantTypeKey, PasswordKey);
                    break;
                case CredentialType.RefreshToken:
                    dict.Add(GrantTypeKey, Refresh);
                    break;
            }

            return dict;
        }

        internal async Task<DelegatingHandler> GetHandlers()
        {
            DelegatingHandler handler = null;
            switch (CredentialType)
            {
                case CredentialType.None:
                    break;
                case CredentialType.ApiKey:
                    handler = new ApiKeyHandler(ApiKey);
                    handler.InnerHandler = new HttpClientHandler();
                    break;
                case CredentialType.ClientCredentials:
                case CredentialType.ResourceOwner:
                case CredentialType.RefreshToken:
                    handler = new ApiKeyHandler(ApiKey);
                    var bearerTokenHandler = new BearerTokenHandler(await GetAccessToken());
                    bearerTokenHandler.InnerHandler = new HttpClientHandler();
                    handler.InnerHandler = bearerTokenHandler;
                    break;
            }

            return handler;
        }

        internal async Task<Token> GetAccessToken()
        {
            if (CredentialType != CredentialType.ClientCredentials && CredentialType != CredentialType.ResourceOwner &&
                CredentialType != CredentialType.RefreshToken
                ||
                (_accessToken != null && _accessToken.Expiration >= DateTime.UtcNow.AddMinutes(-5)))
            {
                return _accessToken;
            }

            var helper = new WebHelper(this, _baseUrl, null);
            var response = await helper.PostForm(GetCredentialsDictionary(), Oauth2TokenPath, null, null, false);
            _accessToken = new Token
            {
                AccessToken = response.access_token.ToString(),
                Expiration =
                    DateTime.UtcNow.Add(TimeSpan.FromSeconds((double) response.expires_in)),
                RefreshToken = response.refresh_token
            };

            return _accessToken;
        }

        internal void ResetAccessToken()
        {
            _accessToken = null;
        }

        public static Credentials GetInstance(string apiKey, string apiSecret, string baseUrl)
        {
            return new Credentials(apiKey, apiSecret, baseUrl);
        }

        public static Credentials GetInstance(string apiKey, string apiSecret, string userName, string userPassword,
            string baseUrl)
        {
            return new Credentials(apiKey, apiSecret, userName, userPassword, baseUrl);
        }

        public static Credentials GetInstance(string apiKey, string apiSecret, string refreshToken, string baseUrl)
        {
            return new Credentials(apiKey, apiSecret, refreshToken, baseUrl);
        }
    }
}