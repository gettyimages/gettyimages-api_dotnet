using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class SearchVideos : ApiRequest
    {
        protected const string V3SearchVideosPath = "/search/videos";

        private SearchVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchVideos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchVideos(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchVideosPath;

            return await base.ExecuteAsync();
        }

        public SearchVideos WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchVideos WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchVideos WithCollectionCodes(IEnumerable<string> values)
        {
            AddCollectionCodes(values);
            return this;
        }

        public SearchVideos WithCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
            return this;
        }

        public SearchVideos WithEditorialVideoType(EditorialVideo value)
        {
            AddEditorialVideoType(value);
            return this;
        }

        public SearchVideos WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Constants.Excludenudity, value);
            return this;
        }

        public SearchVideos WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchVideos WithAvailableFormat(string value)
        {
            AddQueryParameter(Constants.FormatAvailableKey, value);
            return this;
        }

        public SearchVideos WithFrameRate(FrameRate value)
        {
            AddFrameRate(value);
            return this;
        }

        public SearchVideos WithKeywordIds(IEnumerable<int> values)
        {
            AddKeywordIds(values);
            return this;
        }

        public virtual SearchVideos WithLicenseModel(LicenseModel value)
        {
            AddLicenseModel(value);
            return this;
        }

        public SearchVideos WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchVideos WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchVideos WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }

        public SearchVideos WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchVideos WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }

        public SearchVideos WithSpecificPeople(IEnumerable<string> values)
        {
            AddSpecificPeople(values);
            return this;
        }
    }
}
