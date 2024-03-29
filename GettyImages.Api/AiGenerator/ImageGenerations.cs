using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

// TODO - Naming? "GenerateImages"?
// TODO - Generalize: CallAndPollApiRequest
public class ImageGenerations : ApiRequest
{
    private ImageGenerations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
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

    public new Task<ImageGenerationsReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    // TODO - Generalize
    public async Task<ImageGenerationsReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);

        var httpResponseMessage = await helper.PostQueryRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
            path: "/ai/image-generations", BuildHeaders(HeaderParameters), BuildBody());

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
 
    // TODO - Remove
    private string GetPollingPath(HttpResponseMessage httpResponseMessage)
    {
        var pendingResult = httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsPendingResponse>();
        return $"/ai/image-generations/{pendingResult.Result.GenerationRequestId}";
    }
}