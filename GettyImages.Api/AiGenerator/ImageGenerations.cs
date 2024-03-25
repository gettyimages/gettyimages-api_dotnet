using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class ImageGenerations : ApiRequest<ImageGenerationsResponse>
{
    private ImageGenerations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Path = "/ai/image-generations";
        Method = "POST";
    }

    internal static ImageGenerations GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new ImageGenerations(credentials, baseUrl, customHandler);
    }

    public ImageGenerations WithDownloadDetails(ImageGenerationsRequest value)
    {
        BodyParameter = value;
        return this;
    }
}