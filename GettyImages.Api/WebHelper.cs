using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Handlers;

namespace GettyImages.Api
{
    internal class WebHelper
    {
        private readonly string _baseAddress;
        private readonly Credentials _credentials;

        internal WebHelper(Credentials credentials, string baseAddress)
        {
            _credentials = credentials;
            _baseAddress = baseAddress;
        }

        internal async Task<dynamic> Get(IEnumerable<KeyValuePair<string, string>> queryParameters, string path)
        {
            var client = HttpClientFactory.Create(await GetHandlers());
            var uri = _baseAddress + path;
            var builder = new UriBuilder(uri)
            {
                Query =
                    BuildQuery(queryParameters)
            };

            var httpResponse = await client.GetAsync(builder.Uri);
            return await HandleResponse(httpResponse);
        }

        private async Task<DelegatingHandler[]> GetHandlers()
        {
            var handlers = new List<DelegatingHandler>();
            handlers.AddRange(await _credentials.GetHandlers());
            handlers.Add(new UserAgentHandler());
            return handlers.ToArray();
        }

        internal async Task<dynamic> Get(string path)
        {
            var client = HttpClientFactory.Create(await GetHandlers());
            var uri = _baseAddress + path;
            var httpResponse = await client.GetAsync(uri);
            return await HandleResponse(httpResponse);
        }


        internal async Task<dynamic> PostForm(
            IEnumerable<KeyValuePair<string, string>> formParameters,
            string path,
            IEnumerable<DelegatingHandler> handlers)
        {
            using (
                var client =
                    HttpClientFactory.Create(handlers == null
                        ? new DelegatingHandler[] {new UserAgentHandler()}
                        : handlers.ToArray()))
            {
                var uri = _baseAddress + path;
                var httpResponse =
                    await client.PostAsync(uri, new FormUrlEncodedContent(formParameters));

                return await HandleResponse(httpResponse);
            }
        }


        internal async Task<dynamic> PostForm(IEnumerable<KeyValuePair<string, string>> formParameters, string path)
        {
            var handlers = await GetHandlers();
            return PostForm(formParameters, path, handlers);
        }

        internal async Task<dynamic> PostQuery(IEnumerable<KeyValuePair<string, string>> queryParameters, string path)
        {
            using (var client = HttpClientFactory.Create(await GetHandlers()))
            {
                var uri = _baseAddress + path;
                var httpResponse =
                    await
                        client.PostAsync(
                            new UriBuilder(uri) {Query = BuildQuery(queryParameters)}.Uri, null);

                return await HandleResponse(httpResponse);
            }
        }

        private static Task<dynamic> HandleResponse(HttpResponseMessage httpResponse)
        {
            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return httpResponse.Content.ReadAsAsync<dynamic>();
                default:
                    SdkException.GenerateSdkException(httpResponse);
                    return null;
            }
        }

        private static string BuildQuery(IEnumerable<KeyValuePair<string, string>> queryParameters)
        {
            var keyValuePairs = queryParameters as KeyValuePair<string, string>[] ??
                                queryParameters.ToArray();
            return string.Join("&",
                keyValuePairs.Select(d => d.Key + "=" + WebUtility.UrlEncode(d.Value.ToString().ToLowerInvariant())));
        }
    }
}