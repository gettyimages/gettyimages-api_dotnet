using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class SearchImagesCreative : ApiRequest
    {
        protected const string V3SearchImagesPath = "/search/images/creative";

        private SearchImagesCreative(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static SearchImagesCreative GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchImagesCreative(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchImagesPath;

            return await base.ExecuteAsync();
        }

        public SearchImagesCreative WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public SearchImagesCreative WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchImagesCreative WithArtists(IEnumerable<string> values)
        {
            AddArtists(values);
            return this;
        }

        public SearchImagesCreative WithCollectionCodes(IEnumerable<string> values)
        {
            AddCollectionCodes(values);
            return this;
        }

        public SearchImagesCreative WithCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
            return this;
        }

        public SearchImagesCreative WithColor(string value)
        {
            AddQueryParameter(Constants.ColorKey, value);
            return this;
        }

        public SearchImagesCreative WithComposition(Composition value)
        {
            AddComposition(value);
            return this;
        }

        public SearchImagesCreative WithEmbedContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.EmbedContentOnlyKey, value);
            return this;
        }

        public SearchImagesCreative WithEthnicity(Ethnicity value)
        {
            AddEthnicity(value);
            return this;
        }

        public SearchImagesCreative WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Constants.Excludenudity, value);
            return this;
        }
        
        public SearchImagesCreative WithExcludeEditorialUseOnly(bool value = true)
        {
            AddQueryParameter(Constants.ExcludeEditorialUseOnly, value);
            return this;
        }


        public SearchImagesCreative WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public SearchImagesCreative WithFileType(FileType value)
        {
            AddFileTypes(value);
            return this;
        }

        public SearchImagesCreative WithGraphicalStyle(GraphicalStyles value)
        {
            AddGraphicalStyle(value);
            return this;
        }

        public SearchImagesCreative WithGraphicalStyleFilterType(GraphicalStyleFilter value)
        {
            AddQueryParameter(Constants.GraphicalStyleFilterKey, value);
            return this;
        }

        public SearchImagesCreative WithKeywordIds(IEnumerable<int> values)
        {
            AddKeywordIds(values);
            return this;
        }

        public virtual SearchImagesCreative WithLicenseModel(LicenseModel value)
        {
            AddLicenseModel(value);
            return this;
        }

        public SearchImagesCreative WithMinimumSize(MinimumSize value)
        {
            AddQueryParameter(Constants.MinimumSizeKey, value);
            return this;
        }

        public SearchImagesCreative WithNumberOfPeople(NumberOfPeople value)
        {
            AddNumberOfPeople(value);
            return this;
        }

        public SearchImagesCreative WithOrientation(Orientation value)
        {
            AddOrientation(value);
            return this;
        }

        public SearchImagesCreative WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public SearchImagesCreative WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public SearchImagesCreative WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }

        public SearchImagesCreative WithPrestigeContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.PrestigeContentOnlyKey, value);
            return this;
        }

        public SearchImagesCreative WithProductType(ProductType value)
        {
            AddProductTypes(value);
            return this;
        }

        public SearchImagesCreative WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }
    }
}
