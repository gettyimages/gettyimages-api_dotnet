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
        IEditorialImagesSearch WithEditorialSegment(EditorialSegment segment);
    }
}