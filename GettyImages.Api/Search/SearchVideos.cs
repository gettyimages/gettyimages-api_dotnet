using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchVideos : AssetSearch, IBlendedVideosSearch, ICreativeVideosSearch, IEditorialVideosSearch
    {
        private const string V3SearchVideosPath = "/search/videos";

        private SearchVideos(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = string.IsNullOrEmpty(AssetFamily) ? V3SearchVideosPath : V3SearchVideosPath + "/" + AssetFamily;

            if (Fields.Any())
            {
                AddQueryParameter(Constants.FieldsKey, Fields);
            }

            return await base.ExecuteAsync();
        }


        public SearchVideos WithPage(int value)
        {
            AddPage(value);
            return this;
        }

        public ICreativeVideosSearch Creative()
        {
            AssetFamily = "creative";
            return this;
        }

        public IEditorialVideosSearch Editorial()
        {
            AssetFamily = "editorial";
            return this;
        }

        public SearchVideos WithPageSize(int value)
        {
            AddPageSize(value);
            return this;
        }

        public SearchVideos WithPhrase(string value)
        {
            AddPhrase(value);
            return this;
        }

        public SearchVideos WithSortOrder(string value)
        {
            AddSortOrder(value);
            return this;
        }

        public SearchVideos WithExcludeNudity(bool value = true)
        {
            AddExcludeNudity(value);
            return this;
        }

        public SearchVideos WithResponseField(string value)
        {
            AddResponseField(value);
            return this;
        }

        public SearchVideos WithResponseFields(IList<string> value)
        {
            AddResponseFieldRange(value);
            return this;
        }

        public SearchVideos WithProductType(ProductType value)
        {
            AddProductType(value);
            return this;
        }

        public SearchVideos WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchVideos WithCollectionCode(string value)
        {
            AddCollectionCode(value);
            return this;
        }

        public SearchVideos WithCollectionFilterType(CollectionFilter value)
        {
            AddCollectionFilterType(value);
            return this;
        }

        public SearchVideos WithSpecificPeople(string value)
        {
            AddSpecificPeople(value);
            return this;
        }

        internal static SearchVideos GetInstance(Credentials credentials, string baseUrl)
        {
            return new SearchVideos(credentials, baseUrl);
        }

        public SearchVideos WithAvailableFormat(string value)
        {
            AddQueryParameter(Constants.FormatAvailableKey, value);
            return this;
        }

        public SearchVideos WithLicenseModel(LicenseModel value)
        {
            if ((value & LicenseModel.RightsManaged) == LicenseModel.RightsManaged)
            {
                throw new SdkException(LicenseModel.RightsManaged + " is not a valid License Model for video searches.");
            }

            AddLicenseModel(value);
            return this;
        }
    }
}