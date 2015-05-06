using System;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    /// <summary>
    ///     Main entry point to the Getty Images API SDK
    /// </summary>
    public class ApiClient
    {
        private const string Slash = "/";
        private readonly Credentials _credentials;
        private string _baseUrl;

        private ApiClient(string baseUrl)
        {
            NormalizeAndSetBaseUrl(baseUrl);
        }

        private ApiClient(string apiKey, string apiSecret, string refreshToken,
            string baseUrl) : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, refreshToken, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string baseUrl)
            : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string userName, string userPassword,
            string baseUrl)
            : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, userName, userPassword, GetOAuthBaseUrl());
        }

        public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret,
            string baseUrl = "https://api.gettyimages.com/v3")
        {
            return new ApiClient(apiKey, apiSecret, baseUrl);
        }

        public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
            string userName, string userPassword,
            string baseUrl = "https://api.gettyimages.com/v3")
        {
            return new ApiClient(apiKey, apiSecret, userName, userPassword, baseUrl);
        }

        public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken,
            string baseUrl = "https://api.gettyimages.com/v3")
        {
            return new ApiClient(apiKey, apiSecret, refreshToken, baseUrl);
        }


        /// <summary>
        ///     Begins a download request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Download" />.
        /// </returns>
        public Download Download()
        {
            return Api.Download.GetInstance(_credentials, _baseUrl);
        }

        /// <summary>
        ///     Begin a request for image metadata.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Images" />.
        /// </returns>
        public Images Images()
        {
            return Api.Images.GetInstance(_credentials, _baseUrl);
        }

        /// <summary>
        ///     Begin a search request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Api.Search.Search" />.
        /// </returns>
        public Search.Search Search()
        {
            return Api.Search.Search.GetInstance(_credentials, _baseUrl);
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
            return Api.Videos.GetInstance(_credentials, _baseUrl);
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