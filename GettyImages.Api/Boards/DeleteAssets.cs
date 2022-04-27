using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards;

public class DeleteAssets : ApiRequest
{
    protected const string V3DeleteAssetsPath = "/boards/{0}/assets";

    private DeleteAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }

    internal static DeleteAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new DeleteAssets(credentials, baseUrl, customHandler);
    }

    public override async Task ExecuteVoidAsync()
    {
        Method = "DELETE";
        Path = string.Format(V3DeleteAssetsPath, BoardId);

        await base.ExecuteVoidAsync();
    }

    public DeleteAssets WithBoardId(string value)
    {
        BoardId = value;
        return this;
    }

    public DeleteAssets WithAssetIds(IEnumerable<string> value)
    {
        AddAssetIds(value);
        return this;
    }

    public DeleteAssets WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}