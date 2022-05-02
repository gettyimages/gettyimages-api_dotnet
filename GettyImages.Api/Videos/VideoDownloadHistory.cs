using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Videos;

public class VideoDownloadHistory : ApiRequest<GetAssetDownloadHistoryResponse>
{
    private VideoDownloadHistory(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    internal static VideoDownloadHistory GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new VideoDownloadHistory(credentials, baseUrl, customHandler);
    }

    public VideoDownloadHistory WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public VideoDownloadHistory WithId(string value)
    {
        Path = $"/videos/{value}/downloadhistory";
        return this;
    }

    public VideoDownloadHistory IncludeCompanyDownloads()
    {
        AddQueryParameter(Constants.CompanyDownloadsKey, true);
        return this;
    }
}