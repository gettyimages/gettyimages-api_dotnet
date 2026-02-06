using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards;

public class DeleteAssetsById : ApiRequest
{
    protected const string V3DeleteAssetByIdPath = "/boards/{0}/assets/{1}";

    private DeleteAssetsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }
    protected string AssetId { get; set; }

    internal static DeleteAssetsById GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DeleteAssetsById(credentials, baseUrl, customHandler);
    }

    public override async Task ExecuteAsync()
    {
        Method = "DELETE";
        Path = string.Format(V3DeleteAssetByIdPath, BoardId, AssetId);

        await base.ExecuteAsync();
    }

    public DeleteAssetsById WithBoardId(string value)
    {
        BoardId = value;
        return this;
    }

    public DeleteAssetsById WithAssetId(string value)
    {
        AssetId = value;
        return this;
    }

    public DeleteAssetsById WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
