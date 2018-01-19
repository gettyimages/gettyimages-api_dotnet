using System;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api
{
    public class Download : ApiRequest
    {
        private readonly DelegatingHandler _customHandler;

        private Download(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            _customHandler = customHandler;
            Credentials = credentials;
            BaseUrl = baseUrl;
            DownloadImage.GetInstance(Credentials, baseUrl, customHandler);
        }

        internal static Download GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Download(credentials, baseUrl, customHandler);
        }

        public DownloadVideo Video()
        {
            return DownloadVideo.GetInstance(Credentials, BaseUrl, _customHandler);
        }

        public DownloadImage Image()
        {
            return DownloadImage.GetInstance(Credentials, BaseUrl, _customHandler);
        }
    }
}