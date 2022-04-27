using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;
using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class Downloads : ApiRequest<GetDownloadsResponse>
{
    protected const string V3DownloadsPath = "/downloads";

    private Downloads(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static Downloads GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Downloads(credentials, baseUrl, customHandler);
    }

    public override async Task<GetDownloadsResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = V3DownloadsPath;

        return await base.ExecuteAsync();
    }

    public Downloads WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public Downloads WithCompanyDownloads(bool value = true)
    {
        AddQueryParameter(Constants.CompanyDownloadsKey, value);
        return this;
    }

    public Downloads WithEndDate(string value)
    {
        AddQueryParameter(Constants.EndDateKey, value);
        return this;
    }

    public Downloads WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public Downloads WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public Downloads WithProductType(ProductType value)
    {
        AddQueryParameter(Constants.ProductTypeKey, value);
        return this;
    }

    public Downloads WithStartDate(string value)
    {
        AddQueryParameter(Constants.StartDateKey, value);
        return this;
    }

    public Downloads WithUseTime(string value)
    {
        AddQueryParameter(Constants.UseTimeKey, value);
        return this;
    }
}