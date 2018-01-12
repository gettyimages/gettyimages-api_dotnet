using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchImages : AssetSearch, IBlendedImagesSearch, ICreativeImagesSearch, IEditorialImagesSearch
    {
        private readonly DelegatingHandler _customHandler;
        protected const string V3SearchImagesPath = "/search/images";

        
        protected string AssetType;
        protected EditorialSegment EditorialSegments;
        protected GraphicalStyles GraphicalStyles;
        protected Orientation Orientations;
        protected string SortOrder;

        private SearchImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            _customHandler = customHandler;
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        protected LicenseModel LicenseModel { get; set; }

        public ICreativeImagesSearch Creative()
        {
            AssetType = Constants.CreativeKey;
            return this;
        }

        public IEditorialImagesSearch Editorial()
        {
            AssetType = Constants.EditorialKey;
            return this;
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = string.IsNullOrEmpty(AssetType) ? V3SearchImagesPath : V3SearchImagesPath + "/" + AssetType;

            if (Fields.Any())
            {
                AddQueryParameter(Constants.FieldsKey, Fields);
            }

            return await base.ExecuteAsync();
        }

        public SearchImages WithPage(int value)
        {
            AddPage(value);
            return this;
        }

        public SearchImages WithPageSize(int value)
        {
            AddPageSize(value);
            return this;
        }

        public SearchImages WithPhrase(string value)
        {
            AddPhrase(value);
            return this;
        }

        public SearchImages WithSortOrder(string value)
        {
            AddSortOrder(value);
            return this;
        }

        public SearchImages WithEmbedContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.EmbedContentOnlyKey, value);
            return this;
        }

        public SearchImages WithExcludeNudity(bool value = true)
        {
            AddExcludeNudity(value);
            return this;
        }

        public SearchImages WithResponseField(string value)
        {
            AddResponseField(value);
            return this;
        }

        public SearchImages WithResponseFields(IList<string> value)
        {
            AddResponseFieldRange(value);
            return this;
        }

        public SearchImages WithEditorialSegment(EditorialSegment value)
        {
            if (QueryParameters.ContainsKey(Constants.EditorialSegmentKey))
            {
                QueryParameters[Constants.EditorialSegmentKey] = value == EditorialSegment.None
                    ? value
                    : (EditorialSegment)QueryParameters[Constants.EditorialSegmentKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.EditorialSegmentKey, value);
            }

            return this;
        }

        public SearchImages WithGraphicalStyle(GraphicalStyles value)
        {
            if (QueryParameters.ContainsKey(Constants.GraphicalStylesKey))
            {
                QueryParameters[Constants.GraphicalStylesKey] = value == GraphicalStyles.None
                    ? value
                    : (GraphicalStyles) QueryParameters[Constants.GraphicalStylesKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.GraphicalStylesKey, value);
            }

            return this;
        }

        public SearchImages WithOrientation(Orientation value)
        {
            if (QueryParameters.ContainsKey(Constants.OrientationsKey))
            {
                QueryParameters[Constants.OrientationsKey] = value == Orientation.None
                    ? value
                    : (Orientation) QueryParameters[Constants.OrientationsKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.OrientationsKey, value);
            }

            return this;
        }

        public SearchImages WithProductType(ProductType value)
        {
            AddProductType(value);
            return this;
        }

        public SearchImages WithNumberOfPeople(NumberOfPeople value)
        {
            if (QueryParameters.ContainsKey(Constants.NumberOfPeopleKey))
            {
                QueryParameters[Constants.NumberOfPeopleKey] = value == NumberOfPeople.None
                    ? value
                    : (NumberOfPeople) QueryParameters[Constants.NumberOfPeopleKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.NumberOfPeopleKey, value);
            }

            return this;
        }

        public SearchImages WithLocation(string value)
        {
            if (!QueryParameters.ContainsKey(Constants.LocationKey))
            {
                QueryParameters.Add(Constants.LocationKey, new List<string> {value});
            }
            else
            {
                var locations = (IList<string>) QueryParameters[Constants.LocationKey];
                if (!locations.Contains(value))
                {
                    locations.Add(value);
                }
            }
            return this;
        }

        public SearchImages WithKeywordId(int value)
        {
            AddQueryParameter(Constants.KeywordIdsKey, value);
            return this;
        }

        public SearchImages WithFileType(FileType value)
        {
            if (QueryParameters.ContainsKey(Constants.FileTypeKey))
            {
                QueryParameters[Constants.FileTypeKey] = value == FileType.None
                    ? value
                    : (FileType) QueryParameters[Constants.FileTypeKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.FileTypeKey, value);
            }
            return this;
        }

        public SearchImages WithEventId(int value)
        {
            AddQueryParameter(Constants.EventIdsKey, value);
            return this;
        }

        public SearchImages WithPrestigeContentOnly(bool value = true)
        {
            AddQueryParameter(Constants.PrestigeContentOnlyKey, value);
            return this;
        }

        public SearchImages WithAgeOfPeople(AgeOfPeople value)
        {
            AddAgeOfPeopleFilter(value);
            return this;
        }

        public SearchImages WithComposition(Composition value)
        {
            if (QueryParameters.ContainsKey(Constants.CompositionKey))
            {
                QueryParameters[Constants.CompositionKey] = value == Composition.None
                    ? value
                    : (Composition) QueryParameters[Constants.CompositionKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.CompositionKey, value);
            }

            return this;
        }

        public SearchImages WithArtist(string value)
        {
            if (!QueryParameters.ContainsKey(Constants.ArtistKey))
            {
                QueryParameters.Add(Constants.ArtistKey, new List<string> {value});
            }
            else
            {
                var artists = (IList<string>) QueryParameters[Constants.ArtistKey];
                if (!artists.Contains(value))
                {
                    artists.Add(value);
                }
            }
            return this;
        }

        public SearchImages WithEthnicity(Ethnicity value)
        {
            if (QueryParameters.ContainsKey(Constants.EthnicityKey))
            {
                QueryParameters[Constants.EthnicityKey] = value == Ethnicity.None
                    ? value
                    : (Ethnicity) QueryParameters[Constants.EthnicityKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.EthnicityKey, value);
            }

            return this;
        }

        public SearchImages WithCollectionCode(string value)
        {
            AddCollectionCode(value);
            return this;
        }

        public SearchImages WithDateTo(string value)
        {
            AddQueryParameter(Constants.DateToKey, value);
            return this;
        }

        public SearchImages WithDateFrom(string value)
        {
            AddQueryParameter(Constants.DateFromKey, value);
            return this;
        }

        public SearchImages WithCollectionFilterType(CollectionFilter value)
        {
            AddCollectionFilterType(value);
            return this;
        }

        public SearchImages WithSpecificPeople(string value)
        {
            AddSpecificPeople(value);
            return this;
        }

        public virtual SearchImages WithLicenseModel(LicenseModel value)
        {
            AddLicenseModel(value);
            return this;
        }
        public SearchImages WithAcceptLanguage(string value)
        {
            AddAcceptLanguage(value);
            return this;
        }

        internal static SearchImages GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new SearchImages(credentials, baseUrl, customHandler);
        }
    }
}