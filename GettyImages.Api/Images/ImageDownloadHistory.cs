using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Images;

public class ImageDownloadHistory : ApiRequest<GetDownloadsResponse>
{
    private const string ImageDownloadHistoryPath = "/images/{0}/downloadhistory";
    private string _imageId;

    private ImageDownloadHistory(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static ImageDownloadHistory GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new ImageDownloadHistory(credentials, baseUrl, customHandler);
    }

    public override async Task<GetDownloadsResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = Path = string.Format(ImageDownloadHistoryPath, _imageId);

        return await base.ExecuteAsync();
    }

    public ImageDownloadHistory WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public ImageDownloadHistory WithId(string val)
    {
        _imageId = val;
        return this;
    }

    public ImageDownloadHistory WithCompanyDownloads(bool value = true)
    {
        AddQueryParameter(Constants.CompanyDownloadsKey, value);
        return this;
    }
}