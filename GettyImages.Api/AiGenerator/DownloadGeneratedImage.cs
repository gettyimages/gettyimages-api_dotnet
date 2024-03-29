using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class DownloadGeneratedImage : ApiRequest
{
    private DownloadGeneratedImage(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static DownloadGeneratedImage GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DownloadGeneratedImage(credentials, baseUrl, customHandler);
    }

    public DownloadGeneratedImage With(string generationRequestId, int index,
        GeneratedImageDownloadRequest downloadRequest)
    {
        Path = $"/ai/image-generations/{generationRequestId}/images/{index}/download";
        BodyParameter = downloadRequest;
        return this;
    }

    public new Task<DownloadGeneratedImageReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }

    public async Task<DownloadGeneratedImageReadyResponse> ExecuteAsync(TimeSpan pollDelay, TimeSpan timeout)
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);

        var httpResponseMessage = await helper.PutQueryRawHttpResponseMessageAsync(BuildQuery(QueryParameters),
            path: Path, BuildHeaders(HeaderParameters), BuildBody());

        await httpResponseMessage.HandleResponseAsync();

        if (httpResponseMessage.StatusCode == HttpStatusCode.Accepted)
        {
            var getGeneratedImageDownload = GetGeneratedImageDownload.GetInstance(Credentials, BaseUrl, _customHandler)
                .WithPath(Path);
            return await getGeneratedImageDownload.ExecuteAsync(pollDelay, timeout);
        }

        await httpResponseMessage.HandleResponseAsync();
        return await httpResponseMessage.GetContentHandleResponseAsync<DownloadGeneratedImageReadyResponse>();
    }
}