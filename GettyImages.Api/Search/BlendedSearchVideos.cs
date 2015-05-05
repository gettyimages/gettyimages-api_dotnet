using System.Collections.Generic;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public partial class SearchVideos
    {
        IBlendedVideosSearch IBlendedVideosSearch.WithAvailableFormat(string value)
        {
            return WithAvailableFormat(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithLicenseModel(LicenseModel value)
        {
            return WithLicenseModel(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithPage(int value)
        {
            return WithPage(value);
        }
        IBlendedVideosSearch IBlendedVideosSearch.WithPageSize(int val)
        {
            return WithPageSize(val);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithPhrase(string val)
        {
            return WithPhrase(val);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithSortOrder(string val)
        {
            return WithSortOrder(val);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithExcludeNudity(bool value)
        {
            return WithExcludeNudity(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithResponseField(string value)
        {
            return WithResponseField(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithResponseFields(IList<string> value)
        {
            return WithResponseFields(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithProductType(ProductType value)
        {
            return WithProductType(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithAgeOfPeople(AgeOfPeople value)
        {
            return WithAgeOfPeople(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithCollectionCode(string value)
        {
            return WithCollectionCode(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithCollectionFilterType(CollectionFilter value)
        {
            return WithCollectionFilterType(value);
        }

        IBlendedVideosSearch IBlendedVideosSearch.WithSpecificPeople(string value)
        {
            return WithSpecificPeople(value);
        }
    }
}
