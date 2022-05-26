using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Videos;

public class Videos : ApiRequest<GetVideosDetailsResponse>
{
    private readonly List<string> _videoIds = new();
    

    private Videos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/videos";
        
        AddResponseFields(new[]
        {
            "id", "allowed_use", "artist", "asset_family", "call_for_image", "caption", "clip_length",
            "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "date_created",
            "date_submitted", "download_sizes", "download_product", "editorial_segments",
            "entity_details", "era", "event_ids", "istock_collection", "istock_licenses", "license_model",
            "mastered_to", "object_name", "orientation", "originally_shot_on", "preview", "product_types",
            "quality_rank", "referral_destinations", "shot_speed", "source", "thumb", "title"
        });
    }

    internal static Videos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Videos(credentials, baseUrl, customHandler);
    }

    public Videos WithId(string value)
    {
        AddIds(new []{ value });
        return this;
    }

    public Videos WithIds(IEnumerable<string> value)
    {
        AddIds(value);
        return this;
    }

    public Videos WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
    
    public Videos IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public Videos IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public Videos IncludeDownloads()
    {
        AddResponseField("downloads");
        return this;
    }
}