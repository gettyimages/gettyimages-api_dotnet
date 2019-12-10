using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Videos
{
    public class VideoDownloadHistory : ApiRequest
    {
        private const string VideoDownloadHistoryPath = "/videos/{0}/downloadhistory";
        private string _imageId;

        private VideoDownloadHistory(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static VideoDownloadHistory GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new VideoDownloadHistory(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = Path = string.Format(VideoDownloadHistoryPath, _imageId);

            return await base.ExecuteAsync();
        }

        public VideoDownloadHistory WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public VideoDownloadHistory WithId(string val)
        {
            _imageId = val;
            return this;
        }

        public VideoDownloadHistory WithCompanyDownloads(bool value = true)
        {
            AddQueryParameter(Constants.CompanyDownloadsKey, value);
            return this;
        }
    }
}