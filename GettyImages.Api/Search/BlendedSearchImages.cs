using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchImages
    {
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

        IBlendedImagesSearch IBlendedImagesSearch.WithEventId(int value)
        {
            return WithEventId(value);
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

        IBlendedImagesSearch IBlendedImagesSearch.WithFileType(FileType value)
        {
            return WithFileType(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithKeywordId(int value)
        {
            return WithKeywordId(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithNumberOfPeople(NumberOfPeople value)
        {
            return WithNumberOfPeople(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithPrestigeContentOnly(bool value)
        {
            return WithPrestigeContentOnly(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithLocation(string value)
        {
            return WithLocation(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithComposition(Composition value)
        {
            return WithComposition(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithEthnicity(Ethnicity value)
        {
            return WithEthnicity(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithArtist(string value)
        {
            return WithArtist(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithDateTo(string value)
        {
            return WithDateTo(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithDateFrom(string value)
        {
            return WithDateFrom(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }

        IBlendedImagesSearch IBlendedImagesSearch.WithSpecificPeople(string value)
        {
            return WithSpecificPeople(value);
        }
    }
}