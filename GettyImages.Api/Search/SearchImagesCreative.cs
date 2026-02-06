using System.Collections.Generic;
using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchImagesCreative : ApiRequest<SearchCreativeImagesResponse>
{
    protected List<string> DefaultResponseFields = new()
    {
        "allowed_use", "alternative_ids", "artist", "asset_family", "call_for_image", "caption", "collection_code",
        "collection_id", "collection_name", "color_type", "comp", "copyright", "date_camera_shot", "date_created",
        "date_submitted", "download_product", "graphical_style", "id",
        "istock_collection", "license_model", "max_dimensions", "orientation",
        "preview", "product_types", "quality_rank", "referral_destinations", "thumb", "title",
        "uri_oembed"
    };

    private SearchImagesCreative(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/search/images/creative";
        AddResponseFields(DefaultResponseFields);
    }

    internal static SearchImagesCreative GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchImagesCreative(credentials, baseUrl, customHandler);
    }

    public SearchImagesCreative WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchImagesCreative WithGICountryCode(string value)
    {
        AddHeaderParameter(Constants.GICountryCode, value);
        return this;
    }

    public SearchImagesCreative WithAgeOfPeople(AgeOfPeople value)
    {
        AddAgeOfPeopleFilter(value);
        return this;
    }

    public SearchImagesCreative WithArtists(IEnumerable<string> values)
    {
        AddArtists(values);
        return this;
    }

    public SearchImagesCreative WithCollectionCodes(IEnumerable<string> values)
    {
        AddCollectionCodes(values);
        return this;
    }

    public SearchImagesCreative WithCollectionFilterType(CollectionFilter value)
    {
        AddQueryParameter(Constants.CollectionFilterKey, value);
        return this;
    }

    public SearchImagesCreative WithColor(string value)
    {
        AddQueryParameter(Constants.ColorKey, value);
        return this;
    }

    public SearchImagesCreative WithComposition(Composition value)
    {
        AddComposition(value);
        return this;
    }

    public SearchImagesCreative WithDownloadProduct(ProductType productType, int? productId = null)
    {
        var productTypeString = productType.ToString();
        var value = productId == null ? productTypeString : $"{productTypeString}:{productId}";
        AddQueryParameter(Constants.DownloadProductKey, value);
        return this;
    }

    public SearchImagesCreative WithEmbedContentOnly(bool value = true)
    {
        AddQueryParameter(Constants.EmbedContentOnlyKey, value);
        return this;
    }

    public SearchImagesCreative WithEthnicity(Ethnicity value)
    {
        AddEthnicity(value);
        return this;
    }

    public SearchImagesCreative WithExcludeKeywordIds(IEnumerable<int> values)
    {
        AddExcludeKeywordIds(values);
        return this;
    }

    public SearchImagesCreative WithExcludeNudity(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeNudity, value);
        return this;
    }

    public SearchImagesCreative WithExcludeEditorialUseOnly(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeEditorialUseOnly, value);
        return this;
    }

    public SearchImagesCreative IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchImagesCreative IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchImagesCreative IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }

    public SearchImagesCreative IncludeRelatedSearches(bool value = true)
    {
        AddQueryParameter(Constants.RelatedSearchesKey, value);
        return this;
    }

    public SearchImagesCreative WithFileType(FileType value)
    {
        AddFileTypes(value);
        return this;
    }

    public SearchImagesCreative WithGraphicalStyle(GraphicalStylesCreative value, GraphicalStyleFilter filterType = GraphicalStyleFilter.Include)
    {
        AddGraphicalStyle(value);
        AddQueryParameter(Constants.GraphicalStyleFilterKey, filterType);
        return this;
    }

    public SearchImagesCreative WithKeywordIds(IEnumerable<int> values)
    {
        AddKeywordIds(values);
        return this;
    }

    public SearchImagesCreative WithMinimumSize(MinimumSize value)
    {
        AddQueryParameter(Constants.MinimumSizeKey, value);
        return this;
    }

    public SearchImagesCreative WithNumberOfPeople(NumberOfPeople value)
    {
        AddNumberOfPeople(value);
        return this;
    }

    public SearchImagesCreative WithOrientation(OrientationImages value)
    {
        AddOrientation(value);
        return this;
    }

    public SearchImagesCreative WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchImagesCreative WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchImagesCreative WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public SearchImagesCreative WithSafeSearch(bool value = true)
    {
        AddQueryParameter(Constants.SafeSearch, value);
        return this;
    }

    public SearchImagesCreative WithSortOrder(SortOrderCreative value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }

    public SearchImagesCreative IncludeFacets(bool value = true)
    {
        AddQueryParameter(Constants.IncludeFacetsKey, value);
        return this;
    }

    public SearchImagesCreative WithFacetFields(FacetFieldsCreative value)
    {
        AddFacetFields(value);
        return this;
    }

    public SearchImagesCreative WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
}
