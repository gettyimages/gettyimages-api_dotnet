using System;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class ImageGenerations : ImageGenerationsApiRequest
{
    private ImageGenerations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Path = "/ai/image-generations";
    }

    internal static ImageGenerations GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new ImageGenerations(credentials, baseUrl, customHandler);
    }

    public ImageGenerations With(ImageGenerationsRequest value)
    {
        BodyParameter = value;
        return this;
    }

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }
}