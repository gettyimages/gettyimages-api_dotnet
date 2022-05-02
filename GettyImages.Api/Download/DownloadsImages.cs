using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class DownloadsImages : ApiRequest<DownloadAssetResponse>
{
    private DownloadsImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "POST";
        AddQueryParameter(Constants.AutoDownloadKey, false);
    }

    internal static DownloadsImages GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DownloadsImages(credentials, baseUrl, customHandler);
    }

    public DownloadsImages WithId(string value)
    {
        Path = $"/downloads/images/{value}";
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