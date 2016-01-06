using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GettyImages.Api.Handlers
{
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
}
