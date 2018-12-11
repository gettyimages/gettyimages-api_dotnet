using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class SearchImagesEditorial : ApiRequest
    {
        protected const string V3SearchImagesPath = "/search/images/editorial";

        private SearchImagesEditorial(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchImagesEditorial GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchImagesEditorial(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchImagesPath;

            return await base.ExecuteAsync();
        }

        public SearchImagesEditorial WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchImagesEditorial WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchImagesEditorial WithArtists(IEnumerable<string> values)
        {
            AddArtists(values);
            return this;
        }

        public SearchImagesEditorial WithCollectionCodes(IEnumerable<string> values)
        {
            AddCollectionCodes(values);
            return this;
        }

        public SearchImagesEditorial WithCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
            return this;
        }

        public SearchImagesEditorial WithComposition(Composition value)
        {
            AddComposition(value);
            return this;
        }

        public SearchImagesEditorial WithEditorialSegment(EditorialSegment value)
        {
            AddEditorialSegment(value);
            return this;
        }

        public SearchImagesEditorial WithEmbedContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.EmbedContentOnlyKey, value);
            return this;
        }

        public SearchImagesEditorial WithEndDate(string value)
        {
            AddQueryParameter(Constants.EndDateKey, value);
            return this;
        }

        public SearchImagesEditorial WithEntityUris(IEnumerable<string> values)
        {
            AddEntityUris(values);
            return this;
        }

        public SearchImagesEditorial WithEthnicity(Ethnicity value)
        {
            AddEthnicity(value);
            return this;
        }

        public SearchImagesEditorial WithEventIds(IEnumerable<int> values)
        {
            AddEventIds(values);
            return this;
        }

        public SearchImagesEditorial WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Constants.Excludenudity, value);
            return this;
        }

        public SearchImagesEditorial WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchImagesEditorial WithFileType(FileType value)
        {
            AddFileTypes(value);
            return this;
        }

        public SearchImagesEditorial WithGraphicalStyle(GraphicalStyles value)
        {
            AddGraphicalStyle(value);
            return this;
        }

        public SearchImagesEditorial WithGraphicalStyleFilterType(GraphicalStyleFilter value)
        {
            AddQueryParameter(Constants.GraphicalStyleFilterKey, value);
            return this;
        }

        public SearchImagesEditorial WithKeywordIds(IEnumerable<int> values)
        {
            AddKeywordIds(values);
            return this;
        }

        public SearchImagesEditorial WithMinimumQuality(MinimumQuality value)
        {
            AddQueryParameter(Constants.MinimumQualityKey, value);
            return this;
        }

        public SearchImagesEditorial WithMinimumSize(MinimumSize value)
        {
            AddQueryParameter(Constants.MinimumSizeKey, value);
            return this;
        }

        public SearchImagesEditorial WithNumberOfPeople(NumberOfPeople value)
        {
            AddNumberOfPeople(value);
            return this;
        }

        public SearchImagesEditorial WithOrientation(Orientation value)
        {
            AddOrientation(value);
            return this;
        }

        public SearchImagesEditorial WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchImagesEditorial WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchImagesEditorial WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }

        public SearchImagesEditorial WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchImagesEditorial WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }

        public SearchImagesEditorial WithSpecificPeople(IEnumerable<string> values)
        {
            AddSpecificPeople(values);
            return this;
        }

        public SearchImagesEditorial WithStartDate(string value)
        {
            AddQueryParameter(Constants.StartDateKey, value);
            return this;
        }

        public SearchImagesEditorial WithIncludeFacets(bool value = true)
        {
            AddQueryParameter(Constants.IncludeFacetsKey, value);
            return this;
        }

        public SearchImagesEditorial WithFacetFields(IEnumerable<string> values)
        {
            AddFacetResponseFields(values);
            return this;
        }
        public SearchImagesEditorial WithFacetMaxCount(int value)
        {
            AddQueryParameter(Constants.FacetMaxCountKey, value);
            return this;
        }
    }
}
