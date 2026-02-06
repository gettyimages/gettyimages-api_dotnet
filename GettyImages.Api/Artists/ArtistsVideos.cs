using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Artists;

public class ArtistsVideos : ApiRequest<SearchVideosByArtistResponse>
{
    private ArtistsVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/artists/videos";

        AddResponseFields(new[]
        {
            "id", "allowed_use", "alternative_ids", "artist", "asset_family", "asset_type", "call_for_image",
            "caption", "clip_length",
            "collection_id", "collection_code", "collection_name", "comp", "copyright", "date_created",
            "date_submitted",
            "editorial_segments", "event_ids", "graphical_style",
            "license_model", "max_dimensions", "orientation", "preview", "product_types",
            "quality_rank",
            "referral_destinations", "thumb", "title"
        });
    }

    internal static ArtistsVideos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ArtistsVideos(credentials, baseUrl, customHandler);
    }

    public ArtistsVideos WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public ArtistsVideos WithArtist(string value)
    {
        AddQueryParameter(Constants.ArtistNameKey, value);
        return this;
    }

    public ArtistsVideos WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public ArtistsVideos WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public ArtistsVideos IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }
}
