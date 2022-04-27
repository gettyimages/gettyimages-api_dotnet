using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Artists;

public class ArtistsVideos : ApiRequest<SearchVideosByArtistResponse>
{
    protected const string V3ArtistsVideosPath = "/artists/videos";

    private ArtistsVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static ArtistsVideos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ArtistsVideos(credentials, baseUrl, customHandler);
    }

    public override async Task<SearchVideosByArtistResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = V3ArtistsVideosPath;

        return await base.ExecuteAsync();
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

    public ArtistsVideos WithResponseFields(IEnumerable<string> values)
    {
        AddResponseFields(values);
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
}