using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    /// <summary>
    ///     Main entry point to the Getty Images API SDK
    /// </summary>
    public class ApiClient
    {
        private readonly DelegatingHandler _customHandler;
        private const string Slash = "/";
        private const string DefaultApiUri = "https://api.gettyimages.com/v3";
        private readonly Credentials _credentials;
        private string _baseUrl;

        private ApiClient(string baseUrl, DelegatingHandler customHandler)
        {
            _customHandler = customHandler;
            NormalizeAndSetBaseUrl(baseUrl);
        }

        private ApiClient(string apiKey, string apiSecret, string refreshToken,
            string baseUrl, DelegatingHandler customHandler) : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, refreshToken, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string baseUrl, DelegatingHandler customHandler)
            : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string userName, string userPassword,
            string baseUrl, DelegatingHandler customHandler)
            : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, userName, userPassword, GetOAuthBaseUrl());
        }

        public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret)
        {
            return new ApiClient(apiKey, apiSecret, DefaultApiUri, null);
        }

        public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
            string userName, string userPassword)
        {
            return new ApiClient(apiKey, apiSecret, userName, userPassword, DefaultApiUri, null);
        }

        public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken)
        {
            return new ApiClient(apiKey, apiSecret, refreshToken, DefaultApiUri, null);
        }





        public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret,
            string baseUrl)
        {
            return new ApiClient(apiKey, apiSecret, baseUrl, null);
        }

        public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
            string userName, string userPassword,
            string baseUrl)
        {
            return new ApiClient(apiKey, apiSecret, userName, userPassword, baseUrl, null);
        }

        public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken,
            string baseUrl)
        {
            return new ApiClient(apiKey, apiSecret, refreshToken, baseUrl, null);
        }


        public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret, DelegatingHandler customHandler)
        {
            return new ApiClient(apiKey, apiSecret, DefaultApiUri, customHandler);
        }

        public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
            string userName, string userPassword, DelegatingHandler customHandler)
        {
            return new ApiClient(apiKey, apiSecret, userName, userPassword, DefaultApiUri, customHandler);
        }

        public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken, DelegatingHandler customHandler)
        {
            return new ApiClient(apiKey, apiSecret, refreshToken, DefaultApiUri, customHandler);
        }


        /// <summary>
        ///     Begins a download request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Download" />.
        /// </returns>
        public Download Download()
        {
            return Api.Download.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Begin a request for image metadata.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Images" />.
        /// </returns>
        public Images Images()
        {
            return Api.Images.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Begin a search request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Search.Search" />.
        /// </returns>
        public Search.Search Search()
        {
            return Api.Search.Search.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Gets an access token using the credentials used to construct the <see cref="ApiClient" />
        /// </summary>
        /// <returns>
        ///     The <see cref="Token" />
        /// </returns>
        public async Task<Token> GetAccessToken()
        {
            return await _credentials.GetAccessToken();
        }

        /// <summary>
        ///     Begin a request for video metadata.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Videos" />.
        /// </returns>
        public Videos Videos()
        {
            return Api.Videos.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        private void NormalizeAndSetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl.EndsWith(Slash) ? baseUrl.Remove(baseUrl.Length - 1) : baseUrl;
        }

        private string GetOAuthBaseUrl()
        {
            var oAuthBaseUrl = _baseUrl.Substring(0, _baseUrl.LastIndexOf(Slash, StringComparison.Ordinal));
            return oAuthBaseUrl;
        }
    }
}