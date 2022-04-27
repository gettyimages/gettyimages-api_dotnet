using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;
using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class DownloadsImages : ApiRequest<DownloadAssetResponse>
{
    protected const string V3DownloadImagesPath = "/downloads/images";

    private DownloadsImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        AddQueryParameter(Constants.AutoDownloadKey, false);
    }

    protected string AssetId { get; set; }

    internal static DownloadsImages GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DownloadsImages(credentials, baseUrl, customHandler);
    }

    public override async Task<DownloadAssetResponse> ExecuteAsync()
    {
        Method = "POST";
        Path = V3DownloadImagesPath + "/" + AssetId;

        return await base.ExecuteAsync();
    }

    public DownloadsImages WithId(string value)
    {
        AssetId = value;
        return this;
    }

    public DownloadsImages WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public DownloadsImages WithDownloadDetails(DownloadDetails value)
    {
        BodyParameter = value;
        return this;
    }

    public DownloadsImages WithFileType(FileType value)
    {
        AddQueryParameter(Constants.FileTypeKey, value);
        return this;
    }

    public DownloadsImages WithHeight(int height)
    {
        AddQueryParameter(Constants.HeightKey, height);
        return this;
    }

    public DownloadsImages WithProductId(int value)
    {
        AddQueryParameter(Constants.ProductIdKey, value);
        return this;
    }

    public DownloadsImages WithProductType(ProductType value)
    {
        AddQueryParameter(Constants.ProductTypeKey, value);
        return this;
    }
}