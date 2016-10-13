using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    public class DownloadVideo :AssetDownload
    {
        private DownloadVideo(Credentials credentials, string baseUrl) : base(credentials, baseUrl)
        {
            AssetType = "videos";
        }

        internal static DownloadVideo GetInstance(Credentials credentials, string baseUrl)
        {
            return new DownloadVideo(credentials, baseUrl);
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
