using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface IEditorialVideosSearch : IVideosSearch
    {
        new IEditorialVideosSearch WithPage(int val);
        new IEditorialVideosSearch WithPageSize(int val);
        new IEditorialVideosSearch WithPhrase(string val);
        new IEditorialVideosSearch WithSortOrder(string val);
        new IEditorialVideosSearch WithExcludeNudity(bool value = true);
        new IEditorialVideosSearch WithResponseField(string field);
        new IEditorialVideosSearch WithResponseFields(IList<string> value);
        new IEditorialVideosSearch WithProductType(ProductType value);
        new IEditorialVideosSearch WithAgeOfPeople(AgeOfPeople value);
        new IEditorialVideosSearch WithCollectionCode(string value);
        new IEditorialVideosSearch WithCollectionFilterType(CollectionFilter value);
         IEditorialVideosSearch WithSpecificPeople(string value);
        new IEditorialVideosSearch WithAvailableFormat(string value);
    }
}