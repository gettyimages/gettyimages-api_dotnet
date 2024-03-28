using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GetGeneratedImages : ApiRequest
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
    
    public async Task<ImageGenerationsReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);

        HttpResponseMessage httpResponseMessage;

        try
        {
            var cancellationTokenWithTimeout = new CancellationTokenSource(timeout);
            // TODO - Can we use Polly instead of half-rolling our own timeout logic?

            var loopDelay = TimeSpan.Zero;

            do
            {
                await Task.Delay(loopDelay, cancellationTokenWithTimeout.Token);

                // TODO - Can we utilize GeneratedImages.WithGenerationRequestId? 

                httpResponseMessage = await helper.GetRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
                    path: Path, BuildHeaders(HeaderParameters), cancellationTokenWithTimeout.Token);
                loopDelay = pollDelay;
            } while (httpResponseMessage.StatusCode == HttpStatusCode.Accepted);

            cancellationTokenWithTimeout.Token.ThrowIfCancellationRequested();
        }
        catch (OperationCanceledException)
        {
            throw new SdkException("Call timed out", HttpStatusCode.GatewayTimeout);
        }

        await httpResponseMessage.HandleResponseAsync();

        return await httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsReadyResponse>();
    }

}