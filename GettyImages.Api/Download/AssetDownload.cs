using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    
    public abstract class AssetDownload : ApiRequest
    {
        protected string AssetId { get; set; }
        protected abstract string AssetType { get; set; }
        private const string DownloadsPathString = "/downloads/{0}/{1}";
        private const string IdIsRequired = "Id is required.";
        private const string AutoDownloadKey = "auto_download";

        internal AssetDownload(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            QueryParameters.Add(AutoDownloadKey, false);
        }

        public override Task<dynamic> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(AssetId))
            {
                throw new SdkException(IdIsRequired);
            }
            Method = "POST";
            Path = string.Format(DownloadsPathString, AssetType, AssetId);
            return base.ExecuteAsync();
        }
    }
}
