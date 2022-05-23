using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Images;

public class Images : ApiRequest<GetImagesDetailsResponse>
{
    private Images(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/images";

        AddResponseFields(new[]
        {
            "allowed_use", "alternative_ids", "artist", "artist_title", "asset_family", "call_for_image", "caption",
            "city", "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "country",
            "credit_line", "date_camera_shot", "date_created", "date_submitted", "download_product", "download_sizes",
            "editorial_segments", "editorial_source", "entity_details", "event_ids", "graphical_style", "id",
            "istock_collection", "istock_licenses", "license_model", "links", "max_dimensions", "object_name",
            "orientation", "people", "preview", "product_types", "quality_rank", "referral_destinations",
            "state_province", "thumb", "title", "uri_oembed"
        });
    }

    internal static Images GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Images(credentials, baseUrl, customHandler);
    }

    public Images WithId(string value)
    {
        AddIds(new []{ value });
        return this;
    }

    public Images WithIds(IEnumerable<string> value)
    {
        AddIds(value);
        return this;
    }

    public Images WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
    
    public Images IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }

    public Images IncludeLargestDownloads()
    {
        AddResponseField("largest_downloads");
        return this;
    }

    public Images IncludeDownloads()
    {
        AddResponseField("downloads");
        return this;
    }
}