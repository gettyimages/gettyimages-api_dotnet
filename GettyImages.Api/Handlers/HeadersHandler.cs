using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTests,PublicKey="+
"0024000004800000940000000602000000240000525341310004000001000100a182a8a01ddd98"+
"2ea41be8b6181820cad40060e97fed5cba8c7fd2532600913ef061fbf59c95adf05e6e7ba22429"+
"70d8da87b876e491beacaf535ee6efc348b0bded515a96ccaa1bd2612652f874371003b5d4cb7d"+
"345a33e4ca99b07d94cd339921948548752c17e8c49d9baf8304e4bb735de95fb0a4921b14388b"+
"040472bc")]

namespace GettyImages.Api.Handlers;

internal class HeadersHandler : DelegatingHandler
{
    private readonly IEnumerable<KeyValuePair<string, string>> _headerParameters;

    public HeadersHandler(IEnumerable<KeyValuePair<string, string>> headerParameters)
    {
        _headerParameters = headerParameters;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (_headerParameters != null)
        {
            foreach (var header in _headerParameters)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}