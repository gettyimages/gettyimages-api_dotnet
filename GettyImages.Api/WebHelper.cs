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

        internal async Task<dynamic> Get(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            using (var client = HttpClientFactory.Create(await GetHandlers(headerParameters)))
            {
                var uri = _baseAddress + path;
                var builder = new UriBuilder(uri)
                {
                    Query =
                        BuildQuery(queryParameters)
                };

                var httpResponse = await client.GetAsync(builder.Uri);

                try
                {
                    return await HandleResponse(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = HttpClientFactory.Create(await GetHandlers(headerParameters)))
                    {
                        httpResponse = await retryClient.GetAsync(builder.Uri);
                        return await HandleResponse(httpResponse);
                    }
                }
            }
        }

        private async Task<DelegatingHandler[]> GetHandlers(IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            var handlers = new List<DelegatingHandler>();
            handlers.AddRange(await _credentials.GetHandlers());
            handlers.Add(new UserAgentHandler());
            handlers.Add(new HeadersHandler(headerParameters));

            return handlers.ToArray();
        }

        internal async Task<dynamic> PostForm(IEnumerable<KeyValuePair<string, string>> formParameters, string path)
        {
            var handlers = await GetHandlers();
            return PostForm(formParameters, path, handlers);
        }

        internal async Task<dynamic> PostForm(
            IEnumerable<KeyValuePair<string, string>> formParameters,
            string path, DelegatingHandler[] handlers, IEnumerable<KeyValuePair<string, string>> headerParameters = null, bool shouldRetry = true)
        {
            using (var client = HttpClientFactory.Create(handlers == null
                        ? new DelegatingHandler[] { new UserAgentHandler() }
                        : handlers.ToArray()))
            {
                var uri = _baseAddress + path;
                var httpResponse =
                    await client.PostAsync(uri, new FormUrlEncodedContent(formParameters));

                try
                {
                    return await HandleResponse(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    if (shouldRetry)
                    {
                        _credentials.ResetAccessToken();
                        using (var retryClient = HttpClientFactory.Create(await GetHandlers(headerParameters)))
                        {
                            httpResponse = await retryClient.PostAsync(uri, new FormUrlEncodedContent(formParameters));
                            return await HandleResponse(httpResponse);
                        } 
                    }
                    throw;
                }
            }
        }

        internal async Task<dynamic> PostQuery(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            using (var client = HttpClientFactory.Create(await GetHandlers(headerParameters)))
            {
                var uri = _baseAddress + path;
                var httpResponse =
                    await
                        client.PostAsync(
                            new UriBuilder(uri) {Query = BuildQuery(queryParameters)}.Uri, null);

                try
                {
                    return await HandleResponse(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = HttpClientFactory.Create(await GetHandlers(headerParameters)))
                    {
                        httpResponse = await retryClient.PostAsync(uri, new FormUrlEncodedContent(queryParameters));
                        return await HandleResponse(httpResponse);
                    }
                }
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
                keyValuePairs.Select(d => d.Key + "=" + WebUtility.UrlEncode(d.Value.ToString())));
        }
    }
}