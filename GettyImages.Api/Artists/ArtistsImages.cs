using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Artists;

public class ArtistsImages : ApiRequest<SearchImagesByArtistResponse>
{
    private ArtistsImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/artists/images";

        AddResponseFields(new[]
        {
            "id", "allowed_use", "alternative_ids", "artist", "asset_family", "asset_type", "call_for_image",
            "caption", "collection_id", "collection_code", "collection_name", "comp", "copyright", "date_created",
            "date_submitted", "editorial_segments", "event_ids", "graphical_style", "license_model", "max_dimensions",
            "orientation", "preview", "product_types", "quality_rank", "referral_destinations", "thumb", "title"
        });
    }

    internal static ArtistsImages GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ArtistsImages(credentials, baseUrl, customHandler);
    }

    public ArtistsImages WithArtist(string value)
    {
        AddQueryParameter(Constants.ArtistNameKey, value);
        return this;
    }

    public ArtistsImages WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public ArtistsImages WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public ArtistsImages WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public ArtistsImages IncludeKeywords()
    {
        AddResponseField("keywords");
        return this;
    }
}
