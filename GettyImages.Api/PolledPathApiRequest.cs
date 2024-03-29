using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GettyImages.Api;

public abstract class PolledPathApiRequest<TExecuteResponse> : ApiRequest
{
    protected PolledPathApiRequest(DelegatingHandler customHandler) : base(customHandler)
    {
    }

    public async Task<TExecuteResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
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

        return await httpResponseMessage.GetContentHandleResponseAsync<TExecuteResponse>();
    }
}