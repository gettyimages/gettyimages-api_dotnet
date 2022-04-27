using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Images;

public class Images : ApiRequest<GetImagesDetailsResponse>
{
    private const string Comma = ",";
    private const string IdsKey = "ids";
    private const string ImageBatchPath = "/images";
    private readonly List<string> _imageIds = new();

    private Images(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static Images GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Images(credentials, baseUrl, customHandler);
    }

    public override Task<GetImagesDetailsResponse> ExecuteAsync()
    {
        Method = "GET";
        var ids = string.Join(Comma, _imageIds);
        QueryParameters.Add(IdsKey, ids);
        Path = ImageBatchPath;
        return base.ExecuteAsync();
    }

    public Images WithIds(IEnumerable<string> val)
    {
        _imageIds.AddRange(val);
        return this;
    }

    public Images WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public Images WithResponseFields(IEnumerable<string> values)
    {
        AddResponseFields(values);
        return this;
    }
}