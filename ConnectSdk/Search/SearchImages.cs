using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettyImages.Connect.Search.Entity;

namespace GettyImages.Connect.Search
{
    public partial class SearchImages : ApiRequest, IBlendedImagesSearch, ICreativeImagesSearch, IEditorialImagesSearch
    {
        protected const string V3SearchImagesPath = "/search/images";
        private const string AgeOfPeopleKey = "age_of_people";
        private const string ArtistKey = "artists";
        private const string EditorialKey = "editorial";
        private const string CreativeKey = "creative";
        private const string CollectionCodeKey = "collection_codes";
        private const string CollectionFilterKey = "collections_filter_type";
        private const string CompositionKey = "compositions";
        private const string DateToKey = "date_to";
        private const string DateFromKey = "date_from"; 
        private const string EthnicityKey = "ethnicity";
        private const string EventIdsKey = "event_ids";
        private const string FieldsKey = "fields";
        private const string FileTypeKey = "file_types";
        private const string GraphicalStylesKey = "graphical_styles";
        private const string KeywordIdsKey = "keyword_ids";
        private const string LicenseModelsKey = "license_models";
        private const string LocationKey = "specific_locations";
        private const string NumberOfPeopleKey = "number_of_people";
        private const string OrientationsKey = "orientations";
        private const string PageKey = "page";
        private const string PageSizeKey = "page_size";
        private const string PhraseKey = "phrase";
        private const string PrestigeContentOnlyKey = "prestige_content_only";
        private const string ProductTypesKey = "product_types";
        private const string SortOrderKey = "sort_order";
        private const string SpecificPeopleKey = "specific_people";
        private const string EmbedContentOnlyKey = "embed_content_only";
        private const string Excludenudity = "exclude_nudity";

        protected readonly List<string> Fields = new List<string>();
        protected string AssetType;
        protected EditorialSegment EditorialSegments;
        protected GraphicalStyles GraphicalStyles;
        protected Orientation Orientations;
        protected string SortOrder;

        private SearchImages(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        protected LicenseModel LicenseModel { get; set; }

        public ICreativeImagesSearch Creative()
        {
            AssetType = CreativeKey;
            return this;
        }

        public IEditorialImagesSearch Editorial()
        {
            AssetType = EditorialKey;
            return this;
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = string.IsNullOrEmpty(AssetType) ? V3SearchImagesPath : V3SearchImagesPath + "/" + AssetType;

            if (Fields.Any())
            {
                AddQueryParameter(FieldsKey, Fields);
            }

            return await base.ExecuteAsync();
        }

        public SearchImages WithPage(int value)
        {
            AddQueryParameter(PageKey, value);
            return this;
        }

        public SearchImages WithPageSize(int value)
        {
            AddQueryParameter(PageSizeKey, value);
            return this;
        }

        public SearchImages WithPhrase(string value)
        {
            AddQueryParameter(PhraseKey, value);
            return this;
        }

        public SearchImages WithSortOrder(string value)
        {
            AddQueryParameter(SortOrderKey, value);
            return this;
        }

        public SearchImages WithEmbedContentOnly(bool value = true)
        {
            AddQueryParameter(EmbedContentOnlyKey, value);
            return this;
        }

        public SearchImages WithExcludeNudity(bool value = true)
        {
            AddQueryParameter(Excludenudity, value);
            return this;
        }

        public SearchImages WithResponseField(string value)
        {
            if (!QueryParameters.ContainsKey(FieldsKey))
            {
                QueryParameters.Add(FieldsKey, new List<string> {value});
            }
            else
            {
                var fields = (IList<string>) QueryParameters[FieldsKey];
                if (!fields.Contains(value))
                {
                    fields.Add(value);
                }
            }

            return this;
        }

        public SearchImages WithResponseFields(IList<string> value)
        {
            if (!QueryParameters.ContainsKey(FieldsKey))
            {
                QueryParameters.Add(FieldsKey, value);
            }
            else
            {
                var fields = QueryParameters[FieldsKey] as IEnumerable<string>;
                fields = fields.Union(value).Distinct();
                QueryParameters[FieldsKey] = fields.ToList();
            }

            return this;
        }

        public SearchImages WithGraphicalStyle(GraphicalStyles value)
        {
            if (QueryParameters.ContainsKey(GraphicalStylesKey))
            {
                QueryParameters[GraphicalStylesKey] = value == GraphicalStyles.None
                    ? value
                    : (GraphicalStyles) QueryParameters[GraphicalStylesKey] | value;
            }
            else
            {
                QueryParameters.Add(GraphicalStylesKey, value);
            }

            return this;
        }

        public SearchImages WithOrientation(Orientation value)
        {
            if (QueryParameters.ContainsKey(OrientationsKey))
            {
                QueryParameters[OrientationsKey] = value == Orientation.None
                    ? value
                    : (Orientation) QueryParameters[OrientationsKey] | value;
            }
            else
            {
                QueryParameters.Add(OrientationsKey, value);
            }

            return this;
        }

        public SearchImages WithProductType(ProductType value)
        {
            if (QueryParameters.ContainsKey(ProductTypesKey))
            {
                QueryParameters[ProductTypesKey] = value == ProductType.None
                    ? value
                    : (ProductType)QueryParameters[ProductTypesKey] | value;
            }
            else
            {
                QueryParameters.Add(ProductTypesKey, value);
            }

            return this;
        }

        public SearchImages WithNumberOfPeople(NumberOfPeople value)
        {
            if (QueryParameters.ContainsKey(NumberOfPeopleKey))
            {
                QueryParameters[NumberOfPeopleKey] = value == NumberOfPeople.None
                    ? value
                    : (NumberOfPeople)QueryParameters[NumberOfPeopleKey] | value;
            }
            else
            {
                QueryParameters.Add(NumberOfPeopleKey, value);
            }

            return this;
        }

        public SearchImages WithLocation(string value)
        {
            if (!QueryParameters.ContainsKey(LocationKey))
            {
                QueryParameters.Add(LocationKey, new List<string> { value });
            }
            else
            {
                var locations = (IList<string>)QueryParameters[LocationKey];
                if (!locations.Contains(value))
                {
                    locations.Add(value);
                }
            }
            return this;
        }

        public SearchImages WithKeywordId(int value)
        {
            AddQueryParameter(KeywordIdsKey, value);
            return this;
        }

        public SearchImages WithFileType(FileType value)
        {
            if (QueryParameters.ContainsKey(FileTypeKey))
            {
                QueryParameters[FileTypeKey] = value == FileType.None
                    ? value
                    : (FileType)QueryParameters[FileTypeKey] | value;
            }
            else
            {
                QueryParameters.Add(FileTypeKey, value);
            }
            return this;
        }

        public SearchImages WithEventId(int value)
        {
            AddQueryParameter(EventIdsKey, value);
            return this;
        }

        public SearchImages WithPrestigeContentOnly(bool value = true)
        {
            AddQueryParameter(PrestigeContentOnlyKey, value);
            return this;
        }

        public SearchImages WithAgeOfPeople(AgeOfPeople value)
        {
            if (QueryParameters.ContainsKey(AgeOfPeopleKey))
            {
                QueryParameters[AgeOfPeopleKey] = value == AgeOfPeople.None
                    ? value
                    : (AgeOfPeople)QueryParameters[AgeOfPeopleKey] | value;
            }
            else
            {
                QueryParameters.Add(AgeOfPeopleKey, value);
            }
           
            return this;
        }

        public SearchImages WithComposition(Composition value)
        {
            if (QueryParameters.ContainsKey(CompositionKey))
            {
                QueryParameters[CompositionKey] = value == Composition.None
                    ? value
                    : (Composition)QueryParameters[CompositionKey] | value;
            }
            else
            {
                QueryParameters.Add(CompositionKey, value);
            }

            return this;
        }

        public SearchImages WithArtist(string value)
        {
            if (!QueryParameters.ContainsKey(ArtistKey))
            {
                QueryParameters.Add(ArtistKey, new List<string> { value });
            }
            else
            {
                var artists = (IList<string>)QueryParameters[ArtistKey];
                if (!artists.Contains(value))
                {
                    artists.Add(value);
                }
            }
            return this;
        }

        public SearchImages WithEthnicity(Ethnicity value)
        {
            if (QueryParameters.ContainsKey(EthnicityKey))
            {
                QueryParameters[EthnicityKey] = value == Ethnicity.None
                    ? value
                    : (Ethnicity)QueryParameters[EthnicityKey] | value;
            }
            else
            {
                QueryParameters.Add(EthnicityKey, value);
            }

            return this;
        }

        public SearchImages WithCollectionCode(string value)
        {
            if (!QueryParameters.ContainsKey(CollectionCodeKey))
            {
                QueryParameters.Add(CollectionCodeKey, new List<string> { value });
            }
            else
            {
                var collectionCodes = (IList<string>)QueryParameters[CollectionCodeKey];
                if (!collectionCodes.Contains(value))
                {
                    collectionCodes.Add(value);
                }
            }
            return this;
        }

        public SearchImages WithDateTo(string value)
        {
            AddQueryParameter(DateToKey, value);
            return this;
        }

        public SearchImages WithDateFrom(string value)
        {
            AddQueryParameter(DateFromKey, value);
            return this;
        }

        public SearchImages WithCollectionFilterType(CollectionFilter value)
        {
            if (QueryParameters.ContainsKey(CollectionFilterKey))
            {
                QueryParameters[CollectionFilterKey] = value == CollectionFilter.None
                    ? value
                    : (CollectionFilter)QueryParameters[CollectionFilterKey] | value;
            }
            else
            {
                QueryParameters.Add(CollectionFilterKey, value);
            }

            return this;
        }

        public SearchImages WithSpecificPeople(string value)
        {
            if (!QueryParameters.ContainsKey(SpecificPeopleKey))
            {
                QueryParameters.Add(SpecificPeopleKey, new List<string> { value });
            }
            else
            {
                var peoples = (IList<string>)QueryParameters[SpecificPeopleKey];
                if (!peoples.Contains(value))
                {
                    peoples.Add(value);
                }
            }
            return this;
        }

        private void AddQueryParameter(string key, object value)
        {
            if (QueryParameters.ContainsKey(key))
            {
                QueryParameters[key] = value;
            }
            else
            {
                QueryParameters.Add(key, value);
            }
        }

        public virtual SearchImages WithLicenseModel(LicenseModel value)
        {
            if (QueryParameters.ContainsKey(LicenseModelsKey))
            {
                QueryParameters[LicenseModelsKey] = value == LicenseModel.None
                    ? value
                    : (LicenseModel) QueryParameters[LicenseModelsKey] | value;
            }
            else
            {
                QueryParameters.Add(LicenseModelsKey, value);
            }

            return this;
        }

        internal static SearchImages GetInstance(Credentials credentials, string baseUrl)
        {
            return new SearchImages(credentials, baseUrl);
        }

    }
}