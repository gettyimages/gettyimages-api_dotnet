using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class PutAssets : ApiRequest<AddBoardAssetsResponse>
{
    private PutAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "PUT";
    }

    internal static PutAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new PutAssets(credentials, baseUrl, customHandler);
    }

    public PutAssets WithBoardId(string value)
    {
        Path = $"/boards/{value}/assets";
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