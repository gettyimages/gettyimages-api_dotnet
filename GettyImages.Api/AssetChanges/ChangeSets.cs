using System.Net.Http;

namespace GettyImages.Api.AssetChanges;

public class ChangeSets : ApiRequest<Models.AssetChanges>
{
    private ChangeSets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "PUT";
        Path = "/asset-changes/change-sets";
    }

    internal static ChangeSets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new ChangeSets(credentials, baseUrl, customHandler);
    }

    public ChangeSets WithChannelId(int value)
    {
        AppendMultiValuedQueryParameter(Constants.ChannelIdKey, value);
        return this;
    }

    public ChangeSets WithBatchSize(int value)
    {
        AddQueryParameter(Constants.BatchSizeKey, value);
        return this;
    }
}