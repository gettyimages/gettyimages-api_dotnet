using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchImagesEditorial : ApiRequest<SearchEditorialImagesResponse>
{
    private SearchImagesEditorial(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/search/images/editorial";
        AddResponseFields(new[]
        {
            "allowed_use", "alternative_ids", "artist", "asset_family", "call_for_image", "caption", "collection_code",
            "collection_id", "collection_name", "color_type", "comp", "copyright", "date_camera_shot", "date_created",
            "date_submitted", "download_product", "editorial_segments", "editorial_source", "entity_details",
            "event_ids", "graphical_style", "id", "license_model", "max_dimensions", "orientation", "people", "preview",
            "product_types", "quality_rank", "referral_destinations", "thumb", "title", "uri_oembed"
        });
    }

    internal static SearchImagesEditorial GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchImagesEditorial(credentials, baseUrl, customHandler);
    }

    public SearchImagesEditorial WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchImagesEditorial WithAgeOfPeople(AgeOfPeople value)
    {
        AddAgeOfPeopleFilter(value);
        return this;
    }

    public SearchImagesEditorial WithArtists(IEnumerable<string> values)
    {
        AddArtists(values);
        return this;
    }

    public SearchImagesEditorial WithCollectionCodes(IEnumerable<string> values)
    {
        AddCollectionCodes(values);
        return this;
    }

    public SearchImagesEditorial WithCollectionFilterType(CollectionFilter value)
    {
        AddQueryParameter(Constants.CollectionFilterKey, value);
        return this;
    }

    public SearchImagesEditorial WithComposition(Composition value)
    {
        AddComposition(value);
        return this;
    }

    public SearchImagesEditorial WithDownloadProduct(ProductType value)
    {
        AddDownloadProduct(value);
        return this;
    }

    public SearchImagesEditorial WithEditorialSegment(EditorialSegment value)
    {
        AddEditorialSegment(value);
        return this;
    }

    public SearchImagesEditorial WithEmbedContentOnly(bool value = true)
    {
        AddQueryParameter(Constants.EmbedContentOnlyKey, value);
        return this;
    }

    public SearchImagesEditorial WithEndDate(string value)
    {
        AddQueryParameter(Constants.EndDateKey, value);
        return this;
    }

    public SearchImagesEditorial WithEntityUris(IEnumerable<string> values)
    {
        AddEntityUris(values);
        return this;
    }

    public SearchImagesEditorial WithEthnicity(Ethnicity value)
    {
        AddEthnicity(value);
        return this;
    }

    public SearchImagesEditorial WithEventIds(IEnumerable<int> values)
    {
        AddEventIds(values);
        return this;
    }

    public SearchImagesEditorial WithExcludeKeywordIds(IEnumerable<int> values)
    {
        AddExcludeKeywordIds(values);
        return this;
    }

    public SearchImagesEditorial WithExcludeNudity(bool value = true)
    {
        AddQueryParameter(Constants.ExcludeNudity, value);
        return this;
    }

    public SearchImagesEditorial WithFileType(FileType value)
    {
        AddFileTypes(value);
        return this;
    }

    public SearchImagesEditorial WithGraphicalStyle(GraphicalStyles value, GraphicalStyleFilter filterType = GraphicalStyleFilter.Include)
    {
        AddGraphicalStyle(value);
        AddQueryParameter(Constants.GraphicalStyleFilterKey, filterType);
        return this;
    }

    public SearchImagesEditorial IncludeRelatedSearches(bool value = true)
    {
        AddQueryParameter(Constants.RelatedSearchesKey, value);
        return this;
    }

    public SearchImagesEditorial WithKeywordIds(IEnumerable<int> values)
    {
        AddKeywordIds(values);
        return this;
    }

    public SearchImagesEditorial WithMinimumQuality(MinimumQuality value)
    {
        AddQueryParameter(Constants.MinimumQualityKey, value);
        return this;
    }

    public SearchImagesEditorial WithMinimumSize(MinimumSize value)
    {
        AddQueryParameter(Constants.MinimumSizeKey, value);
        return this;
    }

    public SearchImagesEditorial WithNumberOfPeople(NumberOfPeople value)
    {
        AddNumberOfPeople(value);
        return this;
    }

    public SearchImagesEditorial WithOrientation(OrientationImages value)
    {
        AddOrientation(value);
        return this;
    }

    public SearchImagesEditorial WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchImagesEditorial WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchImagesEditorial WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public SearchImagesEditorial WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchImagesEditorial WithSortOrder(SortOrderEditorial value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }

    public SearchImagesEditorial WithSpecificPeople(IEnumerable<string> values)
    {
        AddSpecificPeople(values);
        return this;
    }

    public SearchImagesEditorial WithStartDate(string value)
    {
        AddQueryParameter(Constants.StartDateKey, value);
        return this;
    }

    public SearchImagesEditorial IncludeFacets()
    {
        AddQueryParameter(Constants.IncludeFacetsKey, true);
        return this;
    }

    public SearchImagesEditorial WithFacetFields(IEnumerable<string> values)
    {
        AddFacetResponseFields(values);
        return this;
    }

    public SearchImagesEditorial WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
    
    public SearchImagesEditorial IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchImagesEditorial IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchImagesEditorial IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }
}