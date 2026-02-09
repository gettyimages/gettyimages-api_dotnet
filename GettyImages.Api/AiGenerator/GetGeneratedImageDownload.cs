using System;
using System.Net.Http;
using System.Threading.Tasks;

using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GetGeneratedImageDownload : PolledPathApiRequest<DownloadGeneratedImageReadyResponse>
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

    internal GetGeneratedImageDownload WithPath(string path)
    {
        Path = path;
        return this;
    }

    public new Task<DownloadGeneratedImageReadyResponse> ExecuteAsync()
    {
        return ExecuteAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(45));
    }
}
