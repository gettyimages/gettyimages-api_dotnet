using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Images;

public class ImageDownloadHistory : ApiRequest<GetDownloadsResponse>
{
    private ImageDownloadHistory(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    internal static ImageDownloadHistory GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new ImageDownloadHistory(credentials, baseUrl, customHandler);
    }

    public ImageDownloadHistory WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public ImageDownloadHistory WithId(string value)
    {
        Path = $"/images/{value}/downloadhistory";
        return this;
    }

    public ImageDownloadHistory WithCompanyDownloads(bool value = true)
    {
        AddQueryParameter(Constants.CompanyDownloadsKey, value);
        return this;
    }
}
