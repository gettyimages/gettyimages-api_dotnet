using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface IBlendedImagesSearch : IImagesSearch
    {
        new IBlendedImagesSearch WithPage(int val);
        new IBlendedImagesSearch WithPageSize(int val);
        new IBlendedImagesSearch WithPhrase(string val);
        new IBlendedImagesSearch WithSortOrder(string val);
        new IBlendedImagesSearch WithEmbedContentOnly(bool value = true);
        new IBlendedImagesSearch WithExcludeNudity(bool value = true);
        new IBlendedImagesSearch WithResponseField(string field);
        new IBlendedImagesSearch WithGraphicalStyle(GraphicalStyles value);
        new IBlendedImagesSearch WithOrientation(Orientation value);
        new IBlendedImagesSearch WithEventId(int value);
        new IBlendedImagesSearch WithFileType(FileType value);
        new IBlendedImagesSearch WithKeywordId(int value);
        new IBlendedImagesSearch WithNumberOfPeople(NumberOfPeople value);
        new IBlendedImagesSearch WithPrestigeContentOnly(bool value = true);
        new IBlendedImagesSearch WithProductType(ProductType value);
        new IBlendedImagesSearch WithLocation(string value);
        new IBlendedImagesSearch WithAgeOfPeople(AgeOfPeople value);
        new IBlendedImagesSearch WithComposition(Composition value);
        new IBlendedImagesSearch WithArtist(string value);
        new IBlendedImagesSearch WithEthnicity(Ethnicity value);
        new IBlendedImagesSearch WithCollectionCode(string value);
        new IBlendedImagesSearch WithDateTo(string value);
        new IBlendedImagesSearch WithDateFrom(string value);
        new IBlendedImagesSearch WithCollectionFilterType(CollectionFilter value);
        new IBlendedImagesSearch WithSpecificPeople(string value);
        IBlendedImagesSearch WithLicenseModel(LicenseModel value);
        ICreativeImagesSearch Creative();
        IEditorialImagesSearch Editorial();
        IBlendedImagesSearch WithAcceptLanguage(string value);
    }
}