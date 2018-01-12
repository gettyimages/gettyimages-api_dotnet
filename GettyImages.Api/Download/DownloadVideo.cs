using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    public class DownloadVideo :AssetDownload
    {
        private DownloadVideo(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(credentials, baseUrl, customHandler)
        {
            AssetType = "videos";
        }

        internal static DownloadVideo GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DownloadVideo(credentials, baseUrl, customHandler);
        }

        protected override sealed string AssetType { get; set; }

        public DownloadVideo WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public DownloadVideo WithSize(string value)
        {
            AddQueryParameter("size", value);
            return this;
        }
    }
}
