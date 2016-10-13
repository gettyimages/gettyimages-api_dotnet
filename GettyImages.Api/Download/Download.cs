using System;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api
{
    public class Download : ApiRequest
    {
        private Download(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            DownloadImage.GetInstance(Credentials, baseUrl);
        }

        internal static Download GetInstance(Credentials credentials, string baseUrl)
        {
            return new Download(credentials, baseUrl);
        }

        public DownloadVideo Video()
        {
            return DownloadVideo.GetInstance(Credentials, BaseUrl);
        }

        public DownloadImage Image()
        {
            return DownloadImage.GetInstance(Credentials, BaseUrl);
        }
    }
}