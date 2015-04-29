using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface ICreativeImagesSearch : IImagesSearch
    {
        new ICreativeImagesSearch WithPage(int val);
        new ICreativeImagesSearch WithPageSize(int val);
        new ICreativeImagesSearch WithPhrase(string val);
        new ICreativeImagesSearch WithSortOrder(string val);
        new ICreativeImagesSearch WithEmbedContentOnly(bool value = true);
        new ICreativeImagesSearch WithExcludeNudity(bool value = true);
        new ICreativeImagesSearch WithResponseField(string field);
        new ICreativeImagesSearch WithGraphicalStyle(GraphicalStyles value);
        new ICreativeImagesSearch WithOrientation(Orientation value);
        new ICreativeImagesSearch WithFileType(FileType value);
        new ICreativeImagesSearch WithKeywordId(int value);
        new ICreativeImagesSearch WithNumberOfPeople(NumberOfPeople value);
        new ICreativeImagesSearch WithPrestigeContentOnly(bool value = true);
        new ICreativeImagesSearch WithProductType(ProductType value);
        new ICreativeImagesSearch WithLocation(string value);
        new ICreativeImagesSearch WithAgeOfPeople(AgeOfPeople value);
        new ICreativeImagesSearch WithComposition(Composition value);
        new ICreativeImagesSearch WithArtist(string value);
        new ICreativeImagesSearch WithEthnicity(Ethnicity value);
        new ICreativeImagesSearch WithCollectionCode(string value);
        new ICreativeImagesSearch WithCollectionFilterType(CollectionFilter value);
        ICreativeImagesSearch WithLicenseModel(LicenseModel value);
    }
}