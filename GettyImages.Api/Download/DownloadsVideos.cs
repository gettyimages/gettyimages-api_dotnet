using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class DownloadsVideos : ApiRequest<DownloadAssetResponse>
{
    protected const string V3DownloadVideosPath = "/downloads/videos";

    private DownloadsVideos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        AddQueryParameter(Constants.AutoDownloadKey, false);
    }

    protected string AssetId { get; set; }

    internal static DownloadsVideos GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DownloadsVideos(credentials, baseUrl, customHandler);
    }

    public override async Task<DownloadAssetResponse> ExecuteAsync()
    {
        Method = "POST";
        Path = V3DownloadVideosPath + "/" + AssetId;

        return await base.ExecuteAsync();
    }

    public DownloadsVideos WithId(string value)
    {
        AssetId = value;
        return this;
    }

    public DownloadsVideos WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public DownloadsVideos WithDownloadDetails(string value)
    {
        StringBodyParameter = value;
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