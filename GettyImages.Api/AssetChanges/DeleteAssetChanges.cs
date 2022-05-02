using System.Net.Http;

namespace GettyImages.Api.AssetChanges;

public class DeleteAssetChanges : ApiRequest
{
    private DeleteAssetChanges(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "DELETE";
        
    }

    internal static DeleteAssetChanges GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DeleteAssetChanges(credentials, baseUrl, customHandler);
    }

    public DeleteAssetChanges WithChangeSetId(long value)
    {
        Path = $"/asset-changes/change-sets/{value}";
        return this;
    }
}