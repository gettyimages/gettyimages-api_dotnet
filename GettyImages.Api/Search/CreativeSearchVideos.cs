using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchVideos
    {
        ICreativeVideosSearch ICreativeVideosSearch.WithAvailableFormat(string value)
        {
            return WithAvailableFormat(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithLicenseModel(LicenseModel value)
        {
            return WithLicenseModel(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithPageSize(int val)
        {
            return WithPageSize(val);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithPhrase(string val)
        {
            return WithPhrase(val);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithSortOrder(string val)
        {
            return WithSortOrder(val);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithResponseField(string value)
        {
            return WithResponseField(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithResponseFields(IList<string> value)
        {
            return WithResponseFields(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }

        ICreativeVideosSearch ICreativeVideosSearch.WithPage(int value)
        {
            return WithPage(value);
        }
    }
}