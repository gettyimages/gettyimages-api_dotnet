using System;
using System.Collections.Generic;
using System.Linq;
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


        internal AssetDownload(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
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
