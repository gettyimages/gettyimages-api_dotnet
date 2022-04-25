using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;
using GettyImages.Api.Models;
using ReleaseStatus = GettyImages.Api.Entity.ReleaseStatus;
using SortOrder = GettyImages.Api.Entity.SortOrder;

namespace GettyImages.Api.Search
{
    public class SearchVideosEditorial : ApiRequest<EditorialVideoSearchResults>
    {
        protected const string V3SearchVideosPath = "/search/videos/editorial";

        private SearchVideosEditorial(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchVideosEditorial GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchVideosEditorial(credentials, baseUrl, customHandler);
        }

        public override async Task<EditorialVideoSearchResults> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchVideosPath;

            return await base.ExecuteAsync();
        }

        public SearchVideosEditorial WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchVideosEditorial WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchVideosEditorial WithCollectionCodes(IEnumerable<string> values)
        {
            AddCollectionCodes(values);
            return this;
        }

        public SearchVideosEditorial WithCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
            return this;
        }

        public SearchVideosEditorial WithDownloadProduct(ProductType value)
        {
            AddDownloadProduct(value);
            return this;
        }

        public SearchVideosEditorial WithEditorialVideoType(EditorialVideo value)
        {
            AddEditorialVideoType(value);
            return this;
        }

        public SearchVideosEditorial WithEntityUris(IEnumerable<string> values)
        {
            AddEntityUris(values);
            return this;
        }

        public SearchVideosEditorial WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Constants.Excludenudity, value);
            return this;
        }

        public SearchVideosEditorial WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchVideosEditorial WithAvailableFormat(string value)
        {
            AddQueryParameter(Constants.FormatAvailableKey, value);
            return this;
        }

        public SearchVideosEditorial WithFrameRate(FrameRate value)
        {
            AddFrameRate(value);
            return this;
        }

        public SearchVideosEditorial WithKeywordIds(IEnumerable<int> values)
        {
            AddKeywordIds(values);
            return this;
        }

        public SearchVideosEditorial WithMinimumVideoClipLength(int value)
        {
            AddMinimumVideoClipLength(value);
            return this;
        }

        public SearchVideosEditorial WithMaximumVideoClipLength(int value)
        {
            AddMaximumVideoClipLength(value);
            return this;
        }

        public SearchVideosEditorial WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchVideosEditorial WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchVideosEditorial WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }

        public SearchVideosEditorial WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchVideosEditorial WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }

        public SearchVideosEditorial WithSpecificPeople(IEnumerable<string> values)
        {
            AddSpecificPeople(values);
            return this;
        }

        public SearchVideosEditorial WithReleaseStatus(ReleaseStatus value)
        {
            AddQueryParameter(Constants.ReleaseStatus, value);
            return this;
        }

        public SearchVideosEditorial WithIncludeFacets(bool value = true)
        {
            AddQueryParameter(Constants.IncludeFacetsKey, value);
            return this;
        }

        public SearchVideosEditorial WithFacetFields(IEnumerable<string> values)
        {
            AddFacetResponseFields(values);
            return this;
        }
        public SearchVideosEditorial WithFacetMaxCount(int value)
        {
            AddQueryParameter(Constants.FacetMaxCountKey, value);
            return this;
        }
    }
}
