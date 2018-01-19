using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Videos
{
    public class VideosSimilar : ApiRequest
    {
        private const string VideosPath = "/videos/{0}/similar";
        protected string AssetId { get; set; }

        private VideosSimilar(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static VideosSimilar GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new VideosSimilar(credentials, baseUrl, customHandler);
        }

        public override Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = string.Format(VideosPath, AssetId);

            return base.ExecuteAsync();
        }

        public VideosSimilar WithId(string val)
        {
            AssetId = val;
            return this;
        }

        public VideosSimilar WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public VideosSimilar WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public VideosSimilar WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public VideosSimilar WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }
    }
}