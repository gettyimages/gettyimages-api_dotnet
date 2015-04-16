using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettyImages.Connect.Search
{
    public class SearchImages : ApiRequest, IBlendedImagesSearch, ICreativeImagesSearch, IEditorialImagesSearch
    {
        protected const string V3SearchImagesPath = "/search/images";
        private const string EditorialKey = "editorial";
        private const string CreativeKey = "creative";
        private const string FieldsKey = "fields";
        private const string GraphicalStylesKey = "graphical_styles";
        private const string LicenseModelsKey = "license_models";
        private const string NumberOfPeopleKey = "number_of_people";
        private const string OrientationsKey = "orientations";
        private const string PageKey = "page";
        private const string PageSizeKey = "page_size";
        private const string PhraseKey = "phrase";
        private const string ProductTypesKey = "product_types";
        private const string SortOrderKey = "sort_order";
        private const string EmbedContentOnlyKey = "embed_content_only";
        private const string Excludenudity = "exclude_nudity";
        private const string PhraseIsRequired = "Phrase is required";

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
            if (!QueryParameters.ContainsKey(PhraseKey) ||
                string.IsNullOrWhiteSpace(QueryParameters[PhraseKey].ToString()))
            {
                throw new SdkException(PhraseIsRequired);
            }

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
                QueryParameters[NumberOfPeopleKey] = value == NumberOfPeople.none
                    ? value
                    : (NumberOfPeople)QueryParameters[NumberOfPeopleKey] | value;
            }
            else
            {
                QueryParameters.Add(NumberOfPeopleKey, value);
            }

            return this;
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithPage(int value)
        {
            return WithPage(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithPageSize(int value)
        {
            return WithPageSize(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithPhrase(string value)
        {
            return WithPhrase(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithSortOrder(string value)
        {
            return WithSortOrder(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithEmbedContentOnly(bool value)
        {
            return WithEmbedContentOnly(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithResponseField(string value)
        {
            return WithResponseField(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithGraphicalStyle(GraphicalStyles value)
        {
            return WithGraphicalStyle(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithOrientation(Orientation value)
        {
            return WithOrientation(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithLicenseModel(LicenseModel value)
        {
            return WithLicenseModel(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithPage(int value)
        {
            return WithPage(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithPageSize(int value)
        {
            return WithPageSize(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithPhrase(string value)
        {
            return WithPhrase(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithSortOrder(string value)
        {
            return WithSortOrder(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithEmbedContentOnly(bool value)
        {
            return WithEmbedContentOnly(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithResponseField(string value)
        {
            return WithResponseField(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithGraphicalStyle(GraphicalStyles value)
        {
            return WithGraphicalStyle(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithOrientation(Orientation value)
        {
            return WithOrientation(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithLicenseModel(LicenseModel value)
        {
            return WithLicenseModel(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithEditorialSegment(EditorialSegment segment)
        {
            EditorialSegments = EditorialSegments | segment;
            return this;
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithPage(int value)
        {
            return WithPage(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithPageSize(int value)
        {
            return WithPageSize(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithPhrase(string value)
        {
            return WithPhrase(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithSortOrder(string value)
        {
            return WithSortOrder(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithEmbedContentOnly(bool value)
        {
            return WithEmbedContentOnly(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithResponseField(string value)
        {
            return WithResponseField(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithGraphicalStyle(GraphicalStyles value)
        {
            return WithGraphicalStyle(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithOrientation(Orientation value)
        {
            return WithOrientation(value);
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