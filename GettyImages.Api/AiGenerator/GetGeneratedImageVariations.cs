using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

// TODO - Naming
public class GetGeneratedImageVariations : ApiRequest
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

    // TODO - Generalize
    public async Task<ImageGenerationsReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);

        var httpResponseMessage = await helper.PostQueryRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
            path: Path, BuildHeaders(HeaderParameters), BuildBody());

        await httpResponseMessage.HandleResponseAsync();

        if (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
        {
            var generationRequestId = httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsPendingResponse>().Result.GenerationRequestId;
            var generatedImages = GetGeneratedImages.GetInstance(Credentials, BaseUrl, _customHandler).WithGenerationRequestId(generationRequestId);
            return await generatedImages.ExecuteAsync(pollDelay, timeout);
        }

        await httpResponseMessage.HandleResponseAsync();
        return await httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsReadyResponse>();
    }
}