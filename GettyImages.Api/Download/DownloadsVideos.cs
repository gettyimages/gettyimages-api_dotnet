using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class DownloadsVideos : ApiRequest<DownloadAssetResponse>
{
    private DownloadsVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "POST";
        AddQueryParameter(Constants.AutoDownloadKey, false);
    }

    internal static DownloadsVideos GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DownloadsVideos(credentials, baseUrl, customHandler);
    }

    public DownloadsVideos WithId(string value)
    {
        Path = $"/downloads/videos/{value}";
        return this;
    }

    public DownloadsVideos WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public DownloadsVideos WithDownloadDetails(DownloadDetails value)
    {
        BodyParameter = value;
        return this;
    }

    public DownloadsVideos WithProductId(int value)
    {
        AddQueryParameter(Constants.ProductIdKey, value);
        return this;
    }

    public DownloadsVideos WithSize(string value)
    {
        AddQueryParameter(Constants.SizeKey, value);
        return this;
    }
}