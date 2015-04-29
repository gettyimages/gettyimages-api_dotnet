using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api
{
    public class Download : ApiRequest
    {
        private const string AutoDownloadKey = "auto_download";
        private const string DownloadsPathString = "/downloads/images/{0}";
        private const string IdIsRequired = "Id is required.";
        private const string FileTypeKey = "file_type";
        private const string HeightKey = "height";
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

            Path = string.Format(DownloadsPathString, _assetId);
            return base.ExecuteAsync();
        }

        public Download WithFileType(FileType value)
        {
            if (QueryParameters.ContainsKey(FileTypeKey))
            {
                QueryParameters[FileTypeKey] = value == FileType.None
                    ? value
                    : (FileType) QueryParameters[FileTypeKey] | value;
            }
            else
            {
                QueryParameters.Add(FileTypeKey, value);
            }
            return this;
        }

        public Download WithAutoDownload(bool value = false)
        {
            QueryParameters.Add(AutoDownloadKey, false);
            return this;
        }

        public Download WithHeight(int height)
        {
            QueryParameters.Add(HeightKey, height);
            return this;
        }
    }
}