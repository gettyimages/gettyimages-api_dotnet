using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Customers;

public class Customers : ApiRequest<CustomerInfoResponse>
{
    private Customers(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/customers/current";
    }

    internal static Customers GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Customers(credentials, baseUrl, customHandler);
    }

    public Customers WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}