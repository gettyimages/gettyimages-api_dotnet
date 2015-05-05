using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchVideos
    {
        IEditorialVideosSearch IEditorialVideosSearch.WithAvailableFormat(string value)
        {
            return WithAvailableFormat(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithPageSize(int val)
        {
            return WithPageSize(val);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithPhrase(string val)
        {
            return WithPhrase(val);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithSortOrder(string val)
        {
            return WithSortOrder(val);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithResponseField(string field)
        {
            return WithResponseField(field);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithResponseFields(IList<string> value)
        {
            return WithResponseFields(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithSpecificPeople(string value)
        {
            return WithSpecificPeople(value);
        }

        IEditorialVideosSearch IEditorialVideosSearch.WithPage(int value)
        {
            return WithPage(value);
        }
    }
}