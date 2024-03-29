using System;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GetGeneratedImages : PolledPathApiRequest<ImageGenerationsReadyResponse>
{
    private GetGeneratedImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    internal static GetGeneratedImages GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GetGeneratedImages(credentials, baseUrl, customHandler);
    }

    public GetGeneratedImages WithGenerationRequestId(string generationRequestId)
    {
        if (string.IsNullOrWhiteSpace(generationRequestId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(generationRequestId));
        Path = $"/ai/image-generations/{generationRequestId}";
        return this;
    }
}
