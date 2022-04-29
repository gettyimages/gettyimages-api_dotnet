using System.Collections.Generic;
using System.Net.Http;

namespace GettyImages.Api.Videos;

public class VideosSimilar : ApiRequest
{
    private VideosSimilar(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    internal static VideosSimilar GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new VideosSimilar(credentials, baseUrl, customHandler);
    }

    public VideosSimilar WithId(string value)
    {
        Path = $"/videos/{value}/similar";
        return this;
    }

    public VideosSimilar WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public VideosSimilar WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public VideosSimilar WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }
}