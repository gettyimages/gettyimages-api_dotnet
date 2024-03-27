using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

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
            var pollingPath = GetPollingPath(httpResponseMessage);

            try
            {
                var cancellationTokenWithTimeout = new CancellationTokenSource(timeout);
                // TODO - Can we use Polly instead of half-rolling our own timeout logic?

                while (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
                {
                    await Task.Delay(pollDelay, cancellationTokenWithTimeout.Token);

                    httpResponseMessage = await helper.GetRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
                        path: pollingPath, BuildHeaders(HeaderParameters), cancellationTokenWithTimeout.Token);
                }

                cancellationTokenWithTimeout.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                throw new SdkException("Call timed out", HttpStatusCode.GatewayTimeout);
            }
        }

        await httpResponseMessage.HandleResponseAsync();

        return await httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsReadyResponse>();
    }
 
    private string GetPollingPath(HttpResponseMessage httpResponseMessage)
    {
        var pendingResult = httpResponseMessage.GetContentHandleResponseAsync<ImageGenerationsPendingResponse>();
        return $"/ai/image-generations/{pendingResult.Result}";
    }
}