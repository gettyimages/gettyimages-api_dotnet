using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class SearchImages : ApiRequest
    {
        protected const string V3SearchImagesPath = "/search/images";


        private SearchImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchImages GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchImages(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchImagesPath;

            return await base.ExecuteAsync();
        }

        public SearchImages WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchImages WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchImages WithArtists(IEnumerable<string> values)
        {
            AddArtists(values);
            return this;
        }

        public SearchImages WithCollectionCodes(IEnumerable<string> values)
        {
            AddCollectionCodes(values);
            return this;
        }

        public SearchImages WithCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
            return this;
        }

        public SearchImages WithColor(string value)
        {
            AddQueryParameter(Constants.ColorKey, value);
            return this;
        }

        public SearchImages WithComposition(Composition value)
        {
            AddComposition(value);
            return this;
        }

        public SearchImages WithEmbedContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.EmbedContentOnlyKey, value);
            return this;
        }

        public SearchImages WithEthnicity(Ethnicity value)
        {
            AddEthnicity(value);
            return this;
        }

        public SearchImages WithEventIds(IEnumerable<int> values)
        {
            AddEventIds(values);
            return this;
        }

        public SearchImages WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Constants.Excludenudity, value);
            return this;
        }

        public SearchImages WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchImages WithFileType(FileType value)
        {
            AddFileTypes(value);
            return this;
        }

        public SearchImages WithGraphicalStyle(GraphicalStyles value)
        {
            AddGraphicalStyle(value);
            return this;
        }

        public SearchImages WithKeywordIds(IEnumerable<int> values)
        {
            AddKeywordIds(values);
            return this;
        }

        public virtual SearchImages WithLicenseModel(LicenseModel value)
        {
            AddLicenseModel(value);
            return this;
        }

        public SearchImages WithMinimumSize(MinimumSize value)
        {
            AddQueryParameter(Constants.MinimumSizeKey, value);
            return this;
        }

        public SearchImages WithNumberOfPeople(NumberOfPeople value)
        {
            AddNumberOfPeople(value);
            return this;
        }

        public SearchImages WithOrientation(Orientation value)
        {
            AddOrientation(value);
            return this;
        }

        public SearchImages WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchImages WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchImages WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }

        public SearchImages WithPrestigeContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.PrestigeContentOnlyKey, value);
            return this;
        }

        public SearchImages WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchImages WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }

        public SearchImages WithSpecificPeople(IEnumerable<string> values)
        {
            AddSpecificPeople(values);
            return this;
        }
    }
}
