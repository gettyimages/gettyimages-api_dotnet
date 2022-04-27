using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetChanges;

public class DeleteAssetChanges : ApiRequest
{
    protected const string V3DeleteAssetChangesPath = "/asset-changes/change-sets";

    private DeleteAssetChanges(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected long ChangeSetId { get; set; }

    internal static DeleteAssetChanges GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DeleteAssetChanges(credentials, baseUrl, customHandler);
    }

    public new async Task ExecuteAsync()
    {
        Method = "DELETE";
        Path = V3DeleteAssetChangesPath + "/" + ChangeSetId;

        await base.ExecuteVoidAsync();
    }

    public DeleteAssetChanges WithChangeSetId(long value)
    {
        ChangeSetId = value;
        return this;
    }
}