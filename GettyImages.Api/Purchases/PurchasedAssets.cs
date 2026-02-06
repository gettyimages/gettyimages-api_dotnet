using System;
using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Purchases;

public class PurchasedAssets : ApiRequest<GetPreviouslyPurchasedAssetsResponse>
{
    private PurchasedAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/purchased-assets";
    }

    internal static PurchasedAssets GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new PurchasedAssets(credentials, baseUrl, customHandler);
    }

    public PurchasedAssets WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public PurchasedAssets WithDateTo(DateTime value)
    {
        AddQueryParameter(Constants.DateToKey, value);
        return this;
    }

    public PurchasedAssets WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public PurchasedAssets WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public PurchasedAssets WithDateFrom(DateTime value)
    {
        AddQueryParameter(Constants.DateFromKey, value);
        return this;
    }

    public PurchasedAssets IncludeCompanyPurchases()
    {
        AddQueryParameter(Constants.CompanyPurchasesKey, true);
        return this;
    }
}
