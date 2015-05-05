using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface ICreativeVideosSearch : IVideosSearch
    {
        new ICreativeVideosSearch WithPage(int val);
        new ICreativeVideosSearch WithPageSize(int val);
        new ICreativeVideosSearch WithPhrase(string val);
        new ICreativeVideosSearch WithSortOrder(string val);
        new ICreativeVideosSearch WithExcludeNudity(bool value = true);
        new ICreativeVideosSearch WithResponseField(string value);
        new ICreativeVideosSearch WithResponseFields(IList<string> value);
        new ICreativeVideosSearch WithProductType(ProductType value);
        new ICreativeVideosSearch WithAgeOfPeople(AgeOfPeople value);
        new ICreativeVideosSearch WithCollectionCode(string value);
        new ICreativeVideosSearch WithCollectionFilterType(CollectionFilter value);
        new ICreativeVideosSearch WithAvailableFormat(string value);
         ICreativeVideosSearch WithLicenseModel(LicenseModel value);
    }
}