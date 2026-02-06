using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Videos;

public class VideosSimilar : ApiRequest<GetSimilarVideosResponse>
{
    private VideosSimilar(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
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

    internal static VideosSimilar GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new VideosSimilar(credentials, baseUrl, customHandler);
    }

    public VideosSimilar WithId(string value)
    {
        Path = $"/videos/{value}/similar";
        return this;
    }

    public VideosSimilar WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public VideosSimilar WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public VideosSimilar WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public VideosSimilar IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public VideosSimilar IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

}
