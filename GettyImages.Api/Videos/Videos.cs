using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Videos;

public class Videos : ApiRequest<GetVideoMetadataResponse>
{
    private const string Comma = ",";
    private const string IdsKey = "ids";
    private const string VideosBatchPath = "/videos";
    private readonly List<string> _videoIds = new();

    private Videos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static Videos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Videos(credentials, baseUrl, customHandler);
    }

    public override Task<GetVideoMetadataResponse> ExecuteAsync()
    {
        Method = "GET";
        var ids = string.Join(Comma, _videoIds);
        QueryParameters.Add(IdsKey, ids);
        Path = VideosBatchPath;
        return base.ExecuteAsync();
    }

    public Videos WithId(string val)
    {
        _videoIds.Add(val);
        return this;
    }

    public Videos WithIds(IEnumerable<string> val)
    {
        _videoIds.AddRange(val);
        return this;
    }

    public Videos WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public Videos WithResponseFields(IEnumerable<string> values)
    {
        AddResponseFields(values);
        return this;
    }
}