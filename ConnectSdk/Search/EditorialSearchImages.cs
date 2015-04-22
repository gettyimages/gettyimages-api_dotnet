using GettyImages.Connect.Search.Entity;

namespace GettyImages.Connect.Search
{
    public partial class SearchImages
    {
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

        IEditorialImagesSearch IEditorialImagesSearch.WithEventId(int value)
        {
            return WithEventId(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithFileType(FileType value)
        {
            return WithFileType(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithKeywordId(int value)
        {
            return WithKeywordId(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithNumberOfPeople(NumberOfPeople value)
        {
            return WithNumberOfPeople(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithLocation(string value)
        {
            return WithLocation(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithComposition(Composition value)
        {
            return WithComposition(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithArtist(string value)
        {
            return WithArtist(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithEthnicity(Ethnicity value)
        {
            return WithEthnicity(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithDateTo(string value)
        {
            return WithDateTo(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithDateFrom(string value)
        {
            return WithDateFrom(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }

        IEditorialImagesSearch IEditorialImagesSearch.WithSpecificPeople(string value)
        {
            return WithSpecificPeople(value);
        }
    }
}
