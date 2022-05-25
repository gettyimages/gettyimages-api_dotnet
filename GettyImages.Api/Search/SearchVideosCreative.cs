using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchVideosCreative : ApiRequest<SearchCreativeVideosResponse>
{
    private SearchVideosCreative(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/search/videos/creative";
        AddResponseFields(new[]
        {
            "allowed_use", "artist", "aspect_ratio", "asset_family", "call_for_image", "caption", "clip_length",
            "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright",
            "date_created", "date_submitted", "download_product", "era", "id", "istock_collection", "license_model",
            "mastered_to", "object_name", "orientation", "originally_shot_on", "preview", "product_types",
            "quality_rank", "referral_destinations", "shot_speed", "thumb", "title"
        });
    }

    internal static SearchVideosCreative GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchVideosCreative(credentials, baseUrl, customHandler);
    }

    public SearchVideosCreative WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchVideosCreative WithAgeOfPeople(AgeOfPeople value)
    {
        AddAgeOfPeopleFilter(value);
        return this;
    }

    public SearchVideosCreative WithArtists(IEnumerable<string> values)
    {
        AddArtists(values);
        return this;
    }

    public SearchVideosCreative WithCollectionCodes(IEnumerable<string> values)
    {
        AddCollectionCodes(values);
        return this;
    }

    public SearchVideosCreative WithCollectionFilterType(CollectionFilter value)
    {
        AddQueryParameter(Constants.CollectionFilterKey, value);
        return this;
    }

    public SearchVideosCreative WithDownloadProduct(ProductType value)
    {
        AddDownloadProduct(value);
        return this;
    }

    public SearchVideosCreative WithExcludeEditorialUseOnly(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeEditorialUseOnly, value);
        return this;
    }

    public SearchVideosCreative WithExcludeNudity(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeNudity, value);
        return this;
    }

    public SearchVideosCreative WithAvailableFormat(string value)
    {
        AddQueryParameter(Constants.FormatAvailableKey, value);
        return this;
    }

    public SearchVideosCreative WithFrameRate(FrameRate value)
    {
        AddFrameRate(value);
        return this;
    }

    public SearchVideosCreative WithKeywordIds(IEnumerable<int> values)
    {
        AddKeywordIds(values);
        return this;
    }

    public virtual SearchVideosCreative WithLicenseModel(LicenseModel value)
    {
        AddLicenseModel(value);
        return this;
    }

    public SearchVideosCreative WithMinimumVideoClipLength(int value)
    {
        AddMinimumVideoClipLength(value);
        return this;
    }

    public SearchVideosCreative WithMaximumVideoClipLength(int value)
    {
        AddMaximumVideoClipLength(value);
        return this;
    }

    public SearchVideosCreative WithOrientation(OrientationVideos value)
    {
        AddOrientation(value);
        return this;
    }

    public SearchVideosCreative WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchVideosCreative WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchVideosCreative WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public SearchVideosCreative WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchVideosCreative WithSafeSearch(bool value = true)
    {
        AddQueryParameter(Constants.SafeSearch, value);
        return this;
    }

    public SearchVideosCreative WithSortOrder(SortOrderCreative value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }

    public SearchVideosCreative WithReleaseStatus(ReleaseStatus value)
    {
        AddQueryParameter(Constants.ReleaseStatus, value);
        return this;
    }

    public SearchVideosCreative IncludeFacets()
    {
        AddQueryParameter(Constants.IncludeFacetsKey, true);
        return this;
    }

    public SearchVideosCreative WithFacetFields(IEnumerable<string> values)
    {
        AddFacetResponseFields(values);
        return this;
    }

    public SearchVideosCreative WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
    
    public SearchVideosCreative IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchVideosCreative IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchVideosCreative IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }
}