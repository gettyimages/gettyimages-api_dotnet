using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchImages
    {
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

        ICreativeImagesSearch ICreativeImagesSearch.WithFileType(FileType value)
        {
            return WithFileType(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithKeywordId(int value)
        {
            return WithKeywordId(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithNumberOfPeople(NumberOfPeople value)
        {
            return WithNumberOfPeople(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithPrestigeContentOnly(bool value)
        {
            return WithPrestigeContentOnly(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithLocation(string value)
        {
            return WithLocation(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithComposition(Composition value)
        {
            return WithComposition(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithArtist(string value)
        {
            return WithArtist(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithEthnicity(Ethnicity value)
        {
            return WithEthnicity(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        ICreativeImagesSearch ICreativeImagesSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }
    }
}