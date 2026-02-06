using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public abstract class ImageGenerationsApiRequest : ApiRequest
{
    protected ImageGenerationsApiRequest(DelegatingHandler customHandler) : base(customHandler)
    {
    }

    public async Task<ImageGenerationsReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);

        var httpResponseMessage = await helper.PostQueryRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
            path: Path, BuildHeaders(HeaderParameters), BuildBody());

        await httpResponseMessage.HandleResponseAsync();

        if (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
        {
            var generationRequestId = httpResponseMessage.HandleGetContentResponseAsync<ImageGenerationsPendingResponse>().Result.GenerationRequestId;
            var generatedImages = GetGeneratedImages.GetInstance(Credentials, BaseUrl, _customHandler).WithGenerationRequestId(generationRequestId);
            return await generatedImages.ExecuteAsync(pollDelay, timeout);
        }

        await httpResponseMessage.HandleResponseAsync();
        return await httpResponseMessage.HandleGetContentResponseAsync<ImageGenerationsReadyResponse>();
    }
}
