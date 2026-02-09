using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Products;

public class Products : ApiRequest<GetProductsResponse>
{
    private Products(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/products";
        AddResponseFields(new[] { "download_requirements" });
    }

    internal static Products GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Products(credentials, baseUrl, customHandler);
    }

    public Products WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
