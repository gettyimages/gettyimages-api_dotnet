using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class SearchImagesCreativeByImage : ApiRequest<SearchCreativeImagesByImageResponse>
{
    protected const string V3SearchImagesPath = "/search/images/creative/by-image";

    private SearchImagesCreativeByImage(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = V3SearchImagesPath;
        AddResponseFields(new[]
        {
            "allowed_use", "alternative_ids", "artist", "asset_family", "call_for_image", "caption", "collection_code",
            "collection_id", "collection_name", "color_type", "comp", "copyright", "date_camera_shot", "date_created",
            "date_submitted", "download_product", "graphical_style", "id", "istock_collection", "license_model",
            "max_dimensions", "orientation", "preview", "product_types", "quality_rank", "referral_destinations",
            "thumb", "title", "uri_oembed"
        });
    }

    internal static SearchImagesCreativeByImage GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchImagesCreativeByImage(credentials, baseUrl, customHandler);
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

    public async Task<SearchImagesCreativeByImage> AddToBucketAndSearchAsync(string imageFilepath)
    {
        var path = await AddToBucket(imageFilepath);
        var url = $"{BaseUrl}{path}";
        return WithImageUrl(url);
    }

    public SearchImagesCreativeByImage WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchImagesCreativeByImage WithImageUrl(string value)
    {
        AddQueryParameter(Constants.ImageUrlKey, value);
        return this;
    }

    public SearchImagesCreativeByImage WithAssetId(string value)
    {
        AddQueryParameter(Constants.AssetIdKey, value);
        return this;
    }

    public SearchImagesCreativeByImage WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchImagesCreativeByImage WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchImagesCreativeByImage WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchImagesCreativeByImage IncludeFacets()
    {
        AddQueryParameter(Constants.IncludeFacetsKey, true);
        return this;
    }

    public SearchImagesCreativeByImage WithFacetFields(FacetFieldsCreative value)
    {
        AddFacetFields(value);
        return this;
    }

    public SearchImagesCreativeByImage WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
    
    public SearchImagesCreativeByImage ExcludeEditorialUseOnly()
    {
        AddQueryParameter("exclude_editorial_use_only", true);
        return this;
    }
    
    public SearchImagesCreativeByImage IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public SearchImagesCreativeByImage IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public SearchImagesCreativeByImage IncludeDownloadSizes()
    {
        AddResponseField("download_sizes");
        return this;
    }
}