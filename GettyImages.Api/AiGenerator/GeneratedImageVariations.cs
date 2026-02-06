using System;
using System.Net.Http;
using System.Threading.Tasks;

using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GeneratedImageVariations : ImageGenerationsApiRequest
{
    private GeneratedImageVariations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    internal static GeneratedImageVariations GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GeneratedImageVariations(credentials, baseUrl, customHandler);
    }

    public GeneratedImageVariations With(string generationRequestId, int index, GenerationVariationsRequest generationVariationsRequest)
    {
        Path = $"/ai/image-generations/{generationRequestId}/images/{index}/variations";
        BodyParameter = generationVariationsRequest;
        return this;
    }
}
