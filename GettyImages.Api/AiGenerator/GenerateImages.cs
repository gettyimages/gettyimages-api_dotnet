using System;
using System.Net.Http;
using System.Threading.Tasks;

using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GenerateImages : ImageGenerationsApiRequest
{
    private GenerateImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Path = "/ai/image-generations";
    }

    internal static GenerateImages GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GenerateImages(credentials, baseUrl, customHandler);
    }

    public GenerateImages WithImageGenerationsRequest(ImageGenerationsRequest value)
    {
        BodyParameter = value;
        return this;
    }

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }
}
