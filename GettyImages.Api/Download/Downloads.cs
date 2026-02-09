using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Download;

public class Downloads : ApiRequest<GetDownloadsResponse>
{
    private Downloads(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/downloads";
    }

    internal static Downloads GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Downloads(credentials, baseUrl, customHandler);
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
        AddQueryParameter(Constants.DateToKey, value);
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
        AddQueryParameter(Constants.DateFromKey, value);
        return this;
    }

    public Downloads WithUseTime(bool value = true)
    {
        AddQueryParameter(Constants.UseTimeKey, value);
        return this;
    }
}
