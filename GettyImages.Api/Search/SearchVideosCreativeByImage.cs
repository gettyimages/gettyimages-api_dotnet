using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchVideosCreativeByImage : ApiRequest<SearchCreativeVideosByImageResponse>
{
    private SearchVideosCreativeByImage(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/search/videos/creative/by-image";
        AddResponseFields(new[]
        {
            "allowed_use", "artist", "aspect_ratio", "asset_family", "call_for_image", "caption", "clip_length",
            "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "date_created",
            "date_submitted", "download_product", "era", "id", "istock_collection", "license_model", "mastered_to",
            "orientation", "originally_shot_on", "preview", "product_types", "quality_rank", "referral_destinations",
            "shot_speed", "thumb", "title"
        });
    }

    internal static SearchVideosCreativeByImage GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchVideosCreativeByImage(credentials, baseUrl, customHandler);
    }

    private async Task<string> AddToBucket(string filepath)
    {
        var g = Guid.NewGuid();
        var path = $"/search/by-image/uploads/{g}";
        var stream = File.OpenRead(filepath);
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);
        var httpContent = new StreamContent(stream);
        httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
        await helper.PutQueryVoidAsync(new List<KeyValuePair<string, string>>(),
            path,
            new List<KeyValuePair<string, string>>(),
            httpContent);
        return path;
    }

    public async Task<SearchVideosCreativeByImage> AddToBucketAndSearchAsync(string imageFilepath)
    {
        var path = await AddToBucket(imageFilepath);
        var url = $"{BaseUrl}{path}";
        return WithImageUrl(url);
    }

    public SearchVideosCreativeByImage WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchVideosCreativeByImage WithImageUrl(string value)
    {
        AddQueryParameter(Constants.ImageUrlKey, value);
        return this;
    }

    public SearchVideosCreativeByImage WithAssetId(string value)
    {
        AddQueryParameter(Constants.AssetIdKey, value);
        return this;
    }

    public SearchVideosCreativeByImage WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchVideosCreativeByImage WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchVideosCreativeByImage WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchVideosCreativeByImage IncludeFacets()
    {
        AddQueryParameter(Constants.IncludeFacetsKey, true);
        return this;
    }

    public SearchVideosCreativeByImage WithFacetFields(FacetFieldsCreative value)
    {
        AddFacetFields(value);
        return this;
    }

    public SearchVideosCreativeByImage WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }

    public SearchVideosCreativeByImage ExcludeEditorialUseOnly()
    {
        AddQueryParameter("exclude_editorial_use_only", true);
        return this;
    }
    
    public SearchVideosCreativeByImage IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchVideosCreativeByImage IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchVideosCreativeByImage IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }
}