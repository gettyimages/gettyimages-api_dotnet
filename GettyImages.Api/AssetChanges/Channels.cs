using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.AssetChanges;

public class Channels : ApiRequest<Channel[]>
{
    private Channels(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/asset-changes/channels";
    }

    internal static Channels GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Channels(credentials, baseUrl, customHandler);
    }
}