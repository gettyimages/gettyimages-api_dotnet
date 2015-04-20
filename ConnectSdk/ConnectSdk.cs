using System;
using System.Threading.Tasks;

namespace GettyImages.Connect
{
    /// <summary>
    ///     Main entry point to the Connect API SDK
    /// </summary>
    public class ConnectSdk
    {
        private const string Slash = "/";
        private readonly Credentials _credentials;
        private string _baseUrl;

        private ConnectSdk(string baseUrl)
        {
            NormalizeAndSetBaseUrl(baseUrl);
        }

        private ConnectSdk(string apiKey, string apiSecret, string refreshToken,
            string baseUrl) : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, refreshToken, GetOAuthBaseUrl());
        }

        private ConnectSdk(string apiKey, string apiSecret, string baseUrl)
            : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, GetOAuthBaseUrl());
        }

        private ConnectSdk(string apiKey, string apiSecret, string userName, string userPassword,
            string baseUrl)
            : this(baseUrl)
        {
            _credentials = Credentials.GetInstance(apiKey, apiSecret, userName, userPassword, GetOAuthBaseUrl());
        }

        public static ConnectSdk GetConnectSdkWithClientCredentials(string apiKey, string apiSecret,
            string baseUrl = "https://api.gettyimages.com/v3")
        {
              return new ConnectSdk(apiKey, apiSecret, baseUrl);  
        }
        public static ConnectSdk GetConnectSdkWithResourceOwnerCredentials(string apiKey, string apiSecret, string userName, string userPassword,
           string baseUrl = "https://api.gettyimages.com/v3")
        {
            return new ConnectSdk(apiKey, apiSecret, userName, userPassword, baseUrl);
        }

        public static ConnectSdk GetConnectSdkWithRefreshToken(string apiKey, string apiSecret, string refreshToken,
           string baseUrl = "https://api.gettyimages.com/v3")
        {
            return new ConnectSdk(apiKey, apiSecret, refreshToken, baseUrl);
        }


        /// <summary>
        ///     Begins a download request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Connect.Download" />.
        /// </returns>
        public Download Download()
        {
            return Connect.Download.GetInstance(_credentials, _baseUrl);
        }

        /// <summary>
        ///     Begin a request for image metadata.
        /// </summary>
        /// <returns>
        ///     The <see cref="Connect.Images" />.
        /// </returns>
        public Images Images()
        {
            return Connect.Images.GetInstance(_credentials, _baseUrl);
        }

        /// <summary>
        ///     Begin a search request.
        /// </summary>
        /// <returns>
        ///     The <see cref="Connect.Search.Search" />.
        /// </returns>
        public Search.Search Search()
        {
            return Connect.Search.Search.GetInstance(_credentials, _baseUrl);
        }

        /// <summary>
        ///     Gets an access token using the credentials used to construct the <see cref="Connect.ConnectSdk" />
        /// </summary>
        /// <returns>
        ///     The <see cref="Connect.Token" />
        /// </returns>
        public async Task<Token> GetAccessToken()
        {
            return await _credentials.GetAccessToken();
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