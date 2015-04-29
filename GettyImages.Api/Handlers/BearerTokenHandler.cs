using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GettyImages.Api.Handlers
{
    internal class BearerTokenHandler : DelegatingHandler
    {
        private readonly Token _accessToken;

        public BearerTokenHandler(Token accessToken)
        {
            _accessToken = accessToken;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_accessToken != null)
            {
                request.Headers.Add("Authorization", "Bearer " + _accessToken.AccessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}