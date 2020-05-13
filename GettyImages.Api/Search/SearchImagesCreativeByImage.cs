using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class SearchImagesCreativeByImage : ApiRequest
    {
        protected const string V3SearchImagesPath = "/search/images/creative/by-image";

        private SearchImagesCreativeByImage(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchImagesCreativeByImage GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchImagesCreativeByImage(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchImagesPath;

            return await base.ExecuteAsync();
        }

        private string AddToBucket(string filepath)
        {
            Guid g = new Guid();
            g = Guid.NewGuid();
            string path = "https://search-by-image.s3.amazonaws.com/" + g;
            var client = new HttpClient();
            var stream = File.OpenRead(filepath);
            client.PutAsync(path, new StreamContent(stream)).Wait();
            return path;
        }

        public SearchImagesCreativeByImage AddToBucketAndSearch(string imageFilepath)
        {
            var url = AddToBucket(imageFilepath);
            WithImageUrl(url);
            return this;
        }

        public SearchImagesCreativeByImage WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchImagesCreativeByImage WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchImagesCreativeByImage WithImageFingerprint(string value)
        {
            AddQueryParameter(Constants.ImageFingerprintKey, value);
            return this;
        }

        public SearchImagesCreativeByImage WithImageUrl(string value)
        {
            AddQueryParameter(Constants.ImageUrlKey, value);
            return this;
        }

        public SearchImagesCreativeByImage WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchImagesCreativeByImage WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchImagesCreativeByImage WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchImagesCreativeByImage WithIncludeFacets(bool value = true)
        {
            AddQueryParameter(Constants.IncludeFacetsKey, value);
            return this;
        }

        public SearchImagesCreativeByImage WithFacetFields(IEnumerable<string> values)
        {
            AddFacetResponseFields(values);
            return this;
        }
        public SearchImagesCreativeByImage WithFacetMaxCount(int value)
        {
            AddQueryParameter(Constants.FacetMaxCountKey, value);
            return this;
        }
    }
}
