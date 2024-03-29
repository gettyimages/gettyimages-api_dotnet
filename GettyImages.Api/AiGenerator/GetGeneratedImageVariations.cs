using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GetGeneratedImageVariations : ImageGenerationsApiRequest
{
    private GetGeneratedImageVariations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    internal static GetGeneratedImageVariations GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GetGeneratedImageVariations(credentials, baseUrl, customHandler);
    }
    
    public GetGeneratedImageVariations With(string generationRequestId, int index, GenerationVariationsRequest generationVariationsRequest)
    {
        Path = $"/ai/image-generations/{generationRequestId}/images/{index}/variations";
        BodyParameter = generationVariationsRequest;
        return this;
    }
}