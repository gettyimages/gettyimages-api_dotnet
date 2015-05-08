using System;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api
{
    public class Download : ApiRequest
    {
        private readonly DownloadImage _downloadImage;

        private Download(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            _downloadImage = DownloadImage.GetInstance(Credentials, baseUrl);
        }

        internal static Download GetInstance(Credentials credentials, string baseUrl)
        {
            return new Download(credentials, baseUrl);
        }

        [Obsolete("Use Download().Image().WithId() instead")]
        public Download WithId(string value)
        {
            _downloadImage.WithId(value);
            return this;
        }

        [Obsolete("Use Download().Image().ExecuteAsync() instead")]
        public new Task<dynamic> ExecuteAsync()
        {
            return _downloadImage.ExecuteAsync();
        }

        [Obsolete("Use Download().Image().WithFileType() instead")]
        public Download WithFileType(FileType value)
        {
            _downloadImage.WithFileType(value);
            return this;
        }

        [Obsolete("Use Download().Image().WithAutoDownload() instead")]
        public Download WithAutoDownload(bool value = false)
        {
            _downloadImage.WithAutoDownload(value);
            return this;
        }

        [Obsolete("Use Download().Image().WithHeight() instead")]
        public Download WithHeight(int height)
        {
            _downloadImage.WithHeight(height);
            return this;
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