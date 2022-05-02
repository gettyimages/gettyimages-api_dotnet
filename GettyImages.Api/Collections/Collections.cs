using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Collections;

public class Collections : ApiRequest<GetCollectionsResponse>
{
    private Collections(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/collections";
    }

    internal static Collections GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Collections(credentials, baseUrl, customHandler);
    }

    public Collections WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}