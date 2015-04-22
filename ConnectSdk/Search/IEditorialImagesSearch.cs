namespace GettyImages.Connect.Search
{
    public interface IEditorialImagesSearch : IImagesSearch
    {
        new IEditorialImagesSearch WithPage(int val);
        new IEditorialImagesSearch WithPageSize(int val);
        new IEditorialImagesSearch WithPhrase(string val);
        new IEditorialImagesSearch WithSortOrder(string val);
        new IEditorialImagesSearch WithEmbedContentOnly(bool value = true);
        new IEditorialImagesSearch WithExcludeNudity(bool value = true);
        new IEditorialImagesSearch WithResponseField(string field);
        new IEditorialImagesSearch WithGraphicalStyle(GraphicalStyles value);
        new IEditorialImagesSearch WithOrientation(Orientation value);
        new IEditorialImagesSearch WithEventId(int value);
        new IEditorialImagesSearch WithFileType(FileType value);
        new IEditorialImagesSearch WithKeywordId(int value);
        new IEditorialImagesSearch WithNumberOfPeople(NumberOfPeople value);
        new IEditorialImagesSearch WithProductType(ProductType value);
        new IEditorialImagesSearch WithLocation(string value);
        new IEditorialImagesSearch WithAgeOfPeople(AgeOfPeople value);
        new IEditorialImagesSearch WithComposition(Composition value);
        new IEditorialImagesSearch WithArtist(string value);
        new IEditorialImagesSearch WithEthnicity(Ethnicity value);
        new IEditorialImagesSearch WithCollectionCode(string value);
        new IEditorialImagesSearch WithDateTo(string value);
        new IEditorialImagesSearch WithDateFrom(string value);
        new IEditorialImagesSearch WithCollectionFilterType(CollectionFilter value);
        new IEditorialImagesSearch WithSpecificPeople(string value);
        IEditorialImagesSearch WithEditorialSegment(EditorialSegment segment);
    }
}