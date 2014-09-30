using System.Threading.Tasks;

namespace GettyImages.Connect
{
    public class Download : ApiRequest
    {
        private const string AutoDownloadString = "auto_download";
        private const string DownloadsPathString = "/downloads/{0}";
        private const string IdIsRequired = "Id is required.";
        private string _assetId;

        private Download(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "POST";
        }

        internal static Download GetInstance(Credentials credentials, string baseUrl)
        {
            return new Download(credentials, baseUrl);
        }

        public Download WithId(string val)
        {
            _assetId = val;
            return this;
        }

        public override Task<dynamic> ExecuteAsync()
        {
            if (string.IsNullOrEmpty(_assetId))
            {
                throw new SdkException(IdIsRequired);
            }

            QueryParameters.Clear();
            QueryParameters.Add(AutoDownloadString, false);
            Path = string.Format(DownloadsPathString, _assetId);
            return base.ExecuteAsync();
        }
    }
}