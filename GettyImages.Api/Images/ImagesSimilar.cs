using System.Collections.Generic;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Images;

public class ImagesSimilar : ApiRequest<GetSimilarImagesResponse>
{
    private ImagesSimilar(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    internal static ImagesSimilar GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ImagesSimilar(credentials, baseUrl, customHandler);
    }

    public ImagesSimilar WithId(string value)
    {
        Path = $"/images/{value}/similar";
        return this;
    }

    public ImagesSimilar WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public ImagesSimilar WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public ImagesSimilar WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }
}