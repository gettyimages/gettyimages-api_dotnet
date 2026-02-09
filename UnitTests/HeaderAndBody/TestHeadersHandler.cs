using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using GettyImages.Api.Handlers;

namespace UnitTests.HeaderAndBody;

internal class TestHeadersHandler : HeadersHandler
{
    public TestHeadersHandler(IEnumerable<KeyValuePair<string, string>> headerParameters) : base(headerParameters)
    {
    }

    public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return await base.SendAsync(request, cancellationToken);
    }
}
