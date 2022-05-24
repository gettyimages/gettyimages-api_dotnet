using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchVideosEditorial : ApiRequest<SearchEditorialVideosResponse>
{
    private SearchVideosEditorial(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/search/videos/editorial";
        AddResponseFields(new[]
        {
            "allowed_use", "artist", "aspect_ratio", "asset_family", "call_for_image", "caption", "clip_length",
            "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "date_created",
            "date_submitted", "download_product", "editorial_segments", "entity_details", "era", "event_ids", "id",
            "istock_collection", "license_model", "mastered_to", "object_name", "orientation", "originally_shot_on",
            "preview", "product_types", "quality_rank", "referral_destinations", "shot_speed", "source", "thumb",
            "title", "istock_licenses"
        });
    }

    internal static SearchVideosEditorial GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchVideosEditorial(credentials, baseUrl, customHandler);
    }

   public SearchVideosEditorial WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchVideosEditorial WithAgeOfPeople(AgeOfPeople value)
    {
        AddAgeOfPeopleFilter(value);
        return this;
    }

    public SearchVideosEditorial WithCollectionCodes(IEnumerable<string> values)
    {
        AddCollectionCodes(values);
        return this;
    }

    public SearchVideosEditorial WithCollectionFilterType(CollectionFilter value)
    {
        AddQueryParameter(Constants.CollectionFilterKey, value);
        return this;
    }

    public SearchVideosEditorial WithDownloadProduct(ProductType value)
    {
        AddDownloadProduct(value);
        return this;
    }

    public SearchVideosEditorial WithEditorialVideoType(EditorialVideo value)
    {
        AddEditorialVideoType(value);
        return this;
    }

    public SearchVideosEditorial WithEntityUris(IEnumerable<string> values)
    {
        AddEntityUris(values);
        return this;
    }

    public SearchVideosEditorial WithExcludeNudity(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeNudity, value);
        return this;
    }

    public SearchVideosEditorial WithAvailableFormat(string value)
    {
        AddQueryParameter(Constants.FormatAvailableKey, value);
        return this;
    }

    public SearchVideosEditorial WithFrameRate(FrameRate value)
    {
        AddFrameRate(value);
        return this;
    }

    public SearchVideosEditorial WithKeywordIds(IEnumerable<int> values)
    {
        AddKeywordIds(values);
        return this;
    }

    public SearchVideosEditorial WithMinimumVideoClipLength(int value)
    {
        AddMinimumVideoClipLength(value);
        return this;
    }

    public SearchVideosEditorial WithMaximumVideoClipLength(int value)
    {
        AddMaximumVideoClipLength(value);
        return this;
    }

    public SearchVideosEditorial WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchVideosEditorial WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchVideosEditorial WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public SearchVideosEditorial WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchVideosEditorial WithSortOrder(SortOrderEditorial value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }

    public SearchVideosEditorial WithSpecificPeople(IEnumerable<string> values)
    {
        AddSpecificPeople(values);
        return this;
    }

    public SearchVideosEditorial WithReleaseStatus(ReleaseStatus value)
    {
        AddQueryParameter(Constants.ReleaseStatus, value);
        return this;
    }

    public SearchVideosEditorial IncludeFacets()
    {
        AddQueryParameter(Constants.IncludeFacetsKey, true);
        return this;
    }

    public SearchVideosEditorial WithFacetFields(IEnumerable<string> values)
    {
        AddFacetResponseFields(values);
        return this;
    }

    public SearchVideosEditorial WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
    
    public SearchVideosEditorial IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchVideosEditorial IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchVideosEditorial IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }
}