namespace GettyImages.Connect.Search
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
        IBlendedImagesSearch WithLicenseModel(LicenseModel value);
        ICreativeImagesSearch Creative();
        IEditorialImagesSearch Editorial();
    }
}