using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class PutAssets : ApiRequest<AddBoardAssetsResult>
{
    protected const string V3PutAssetsPath = "/boards/{0}/assets";

    private PutAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }

    internal static PutAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new PutAssets(credentials, baseUrl, customHandler);
    }

    public override async Task<AddBoardAssetsResult> ExecuteAsync()
    {
        Method = "PUT";
        Path = string.Format(V3PutAssetsPath, BoardId);

        return await base.ExecuteAsync();
    }

    public PutAssets WithBoardId(string value)
    {
        BoardId = value;
        return this;
    }

    public PutAssets WithBoardAssets(string value)
    {
        StringBodyParameter = value;
        return this;
    }

    public PutAssets WithAssetIds(IEnumerable<string> value)
    {
        BodyParameter = value.Select(id => new BoardAsset { AssetId = id });
        return this;
    }

    public PutAssets WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}