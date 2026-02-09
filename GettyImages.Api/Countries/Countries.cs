using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Countries;

public class Countries : ApiRequest<GetCountriesResponse>
{
    private Countries(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/countries";
    }

    internal static Countries GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Countries(credentials, baseUrl, customHandler);
    }

    public Countries WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
