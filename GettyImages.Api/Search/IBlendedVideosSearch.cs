using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface IBlendedVideosSearch : IVideosSearch
    {
        new IBlendedVideosSearch WithPage(int val);
        new IBlendedVideosSearch WithPageSize(int val);
        new IBlendedVideosSearch WithPhrase(string val);
        new IBlendedVideosSearch WithSortOrder(string val);
        new IBlendedVideosSearch WithExcludeNudity(bool value = true);
        new IBlendedVideosSearch WithResponseField(string value);
        new IBlendedVideosSearch WithResponseFields(IList<string> value);
        new IBlendedVideosSearch WithProductType(ProductType value);
        new IBlendedVideosSearch WithAgeOfPeople(AgeOfPeople value);
        new IBlendedVideosSearch WithCollectionCode(string value);
        new IBlendedVideosSearch WithCollectionFilterType(CollectionFilter value);
         IBlendedVideosSearch WithSpecificPeople(string value);
        new IBlendedVideosSearch WithAvailableFormat(string value);
         IBlendedVideosSearch WithLicenseModel(LicenseModel value);
        ICreativeVideosSearch Creative();
        IEditorialVideosSearch Editorial();
    }
}