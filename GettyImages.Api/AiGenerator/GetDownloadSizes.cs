using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GetDownloadSizes : ApiRequest<GeneratedDownloadSizesResponse>
{
    private GetDownloadSizes(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        Method = "GET";
        BaseUrl = baseUrl;
    }

    internal static GetDownloadSizes GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GetDownloadSizes(credentials, baseUrl, customHandler);
    }

    public GetDownloadSizes With(string generationRequestId, int index)
    {
        Path = $"/ai/image-generations/{generationRequestId}/images/{index}/download-sizes";
        return this;
    }
}