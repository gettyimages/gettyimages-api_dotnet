using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

// TODO - Naming?
public class GetGeneratedImageDownload : ApiRequest
{
    private GetGeneratedImageDownload(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static GetGeneratedImageDownload GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GetGeneratedImageDownload(credentials, baseUrl, customHandler);
    }

    public GetGeneratedImageDownload With(string generationRequestId, int index)
    {
        Path = $"/ai/image-generations/{generationRequestId}/images/{index}/download";
        return this;
    }

    public new Task<DownloadGeneratedImageReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    // TODO - DRY with GetGeneratedImages.ExecuteAsync
    public async Task<DownloadGeneratedImageReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
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

        return await httpResponseMessage.GetContentHandleResponseAsync<DownloadGeneratedImageReadyResponse>();
    }
}