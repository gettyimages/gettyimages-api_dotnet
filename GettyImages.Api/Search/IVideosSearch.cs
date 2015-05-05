using System.Collections.Generic;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public interface IVideosSearch
    {
        Task<dynamic> ExecuteAsync();
        SearchVideos WithAvailableFormat(string value);
        SearchVideos WithPage(int value);
        SearchVideos WithPageSize(int val);
        SearchVideos WithPhrase(string val);
        SearchVideos WithSortOrder(string val);
        SearchVideos WithExcludeNudity(bool value = true);
        SearchVideos WithResponseField(string value);
        SearchVideos WithResponseFields(IList<string> value);
        SearchVideos WithProductType(ProductType value);
        SearchVideos WithAgeOfPeople(AgeOfPeople value);
        SearchVideos WithCollectionCode(string value);
        SearchVideos WithCollectionFilterType(CollectionFilter value);
    }
}