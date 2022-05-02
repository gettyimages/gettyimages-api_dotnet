using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GettyImages.Api.Handlers;

internal class ApiKeyHandler : DelegatingHandler
{
    private readonly string _apiKey;

    public ApiKeyHandler(string apiKey)
    {
        _apiKey = apiKey;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add("Api-Key", _apiKey);
        return await base.SendAsync(request, cancellationToken);
    }
}