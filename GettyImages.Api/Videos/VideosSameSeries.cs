using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Videos;

public class VideosSameSeries : ApiRequest<GetSimilarVideosResponse>
{
    private VideosSameSeries(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        AddResponseFields(new[]
        {
            "allowed_use", "artist", "aspect_ratio", "asset_family", "call_for_image", "caption", "clip_length",
            "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "date_created",
            "date_submitted", "download_product", "download_sizes", "editorial_segments", "entity_details", "era",
            "event_ids", "id", "istock_collection", "license_model", "mastered_to", "orientation", "originally_shot_on",
            "preview", "product_types", "quality_rank", "referral_destinations", "shot_speed", "source", "thumb",
            "title", "istock_licenses"
        });
    }

    internal static VideosSameSeries GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new VideosSameSeries(credentials, baseUrl, customHandler);
    }

    public VideosSameSeries WithId(string value)
    {
        Path = $"/videos/{value}/same-series";
        return this;
    }

    public VideosSameSeries WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public VideosSameSeries WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public VideosSameSeries WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }
    
    public VideosSameSeries IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public VideosSameSeries IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }
    
}