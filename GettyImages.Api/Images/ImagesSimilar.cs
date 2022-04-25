using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Images
{
    public class ImagesSimilar : ApiRequest<ImageSearchItemSearchResults>
    {
        private const string ImagePath = "/images/{0}/similar";
        protected string AssetId { get; set; }

        private ImagesSimilar(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static ImagesSimilar GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new ImagesSimilar(credentials, baseUrl, customHandler);
        }

        public override Task<ImageSearchItemSearchResults> ExecuteAsync()
        {
            Method = "GET";
            Path = string.Format(ImagePath, AssetId);

            return base.ExecuteAsync();
        }

        public ImagesSimilar WithId(string val)
        {
            AssetId = val;
            return this;
        }

        public ImagesSimilar WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public ImagesSimilar WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public ImagesSimilar WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public ImagesSimilar WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }
    }
}