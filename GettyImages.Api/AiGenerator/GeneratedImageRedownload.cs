using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.AiGenerator;

public class GeneratedImageRedownload : ApiRequest<DownloadGeneratedImageReadyResponse>
{
    private GeneratedImageRedownload(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "POST";
        Path = "/ai/redownloads";
    }

    internal static GeneratedImageRedownload GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new GeneratedImageRedownload(credentials, baseUrl, customHandler);
    }

    public GeneratedImageRedownload With(GeneratedImageRedownloadRequest value)
    {
        BodyParameter = value;
        return this;
    }
}
