using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Orders;

public class Orders : ApiRequest<GetOrderDetailsResponse>
{
    private Orders(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    protected int id { get; set; }

    internal static Orders GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Orders(credentials, baseUrl, customHandler);
    }

    public Orders WithId(long value)
    {
        Path = $"/orders/{value}";
        return this;
    }

    public Orders WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}