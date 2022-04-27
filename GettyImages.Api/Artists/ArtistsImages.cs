using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Artists;

public class ArtistsImages : ApiRequest<SearchImagesByArtistResponse>
{
    protected const string V3ArtistsImagesPath = "/artists/images";

    private ArtistsImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static ArtistsImages GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ArtistsImages(credentials, baseUrl, customHandler);
    }

    public override async Task<SearchImagesByArtistResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = V3ArtistsImagesPath;

        return await base.ExecuteAsync();
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

    public ArtistsImages WithResponseFields(IEnumerable<string> values)
    {
        AddResponseFields(values);
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
}