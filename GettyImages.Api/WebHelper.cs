using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GettyImages.Api.Handlers;
using Newtonsoft.Json;

namespace GettyImages.Api
{
    internal class WebHelper
    {
        private readonly string _baseAddress;
        private readonly DelegatingHandler _customHandler;
        private readonly Credentials _credentials;

        internal WebHelper(Credentials credentials, string baseAddress, DelegatingHandler customHandler)
        {
            _credentials = credentials;
            _baseAddress = baseAddress;
            _customHandler = customHandler;
        }

        internal async Task<dynamic> GetAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            using (var client = new HttpClient(await GetHandlersAsync(headerParameters)))
            {
                var uri = _baseAddress + path;
                var builder = new UriBuilder(uri)
                {
                    Query =
                        BuildQuery(queryParameters)
                };

                var httpResponse = await client.GetAsyncWithRetryPolicy(builder.Uri);

                try
                {
                    return await HandleResponseAsync(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = new HttpClient(await GetHandlersAsync(headerParameters)))
                    {
                        httpResponse = await retryClient.GetAsyncWithRetryPolicy(builder.Uri);
                        return await HandleResponseAsync(httpResponse);
                    }
                }
            }
        }

        internal async Task<dynamic> PostFormAsync(
            IEnumerable<KeyValuePair<string, string>> formParameters,
            string path, DelegatingHandler handlers, IEnumerable<KeyValuePair<string, string>> headerParameters = null, bool shouldRetry = true)
        {
            using (var client = new HttpClient(handlers == null
                        ? new UserAgentHandler()
                        : handlers))
            {
                var uri = _baseAddress + path;
                var formContent = new FormUrlEncodedContent(formParameters);

                var httpResponse = await client.PostAsyncWithRetryPolicy(uri, formContent);

                try
                {
                    return await HandleResponseAsync(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    if (shouldRetry)
                    {
                        _credentials.ResetAccessToken();
                        using (var retryClient = new HttpClient(await GetHandlersAsync(headerParameters)))
                        {
                            httpResponse = await retryClient.PostAsyncWithRetryPolicy(uri, formContent);
                            return await HandleResponseAsync(httpResponse);
                        }
                    }
                    throw;
                }
            }
        }

        internal async Task<dynamic> PostQueryAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter)
        {
            using (var client = new HttpClient(await GetHandlersAsync(headerParameters)))
            {
                var uri = _baseAddress + path;
                var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

                var httpResponse = await client.PostAsyncWithRetryPolicy(requestUri, bodyParameter);

                try
                {
                    return await HandleResponseAsync(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = new HttpClient(await GetHandlersAsync(headerParameters)))
                    {
                        httpResponse = await retryClient.PostAsyncWithRetryPolicy(requestUri, bodyParameter);
                        return await HandleResponseAsync(httpResponse);
                    }
                }
            }
        }

        internal async Task<dynamic> PutQueryAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter, MediaTypeHeaderValue mediaType = null)
        {
            using (var client = new HttpClient(await GetHandlersAsync(headerParameters)))
            {
                var uri = _baseAddress + path;
                var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

                var httpResponse = await client.PutAsyncWithRetryPolicy(requestUri, bodyParameter);

                try
                {
                    return await HandleResponseAsync(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = new HttpClient(await GetHandlersAsync(headerParameters)))
                    {
                        httpResponse = await retryClient.PutAsyncWithRetryPolicy(requestUri, bodyParameter);
                        return await HandleResponseAsync(httpResponse);
                    }
                }
            }
        }

        internal async Task<dynamic> DeleteQueryAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            using (var client = new HttpClient(await GetHandlersAsync(headerParameters)))
            {
                var uri = _baseAddress + path;
                var builder = new UriBuilder(uri)
                {
                    Query =
                        BuildQuery(queryParameters)
                };

                var httpResponse = await client.DeleteAsyncWithRetryPolicy(builder.Uri);

                try
                {
                    return await HandleResponseAsync(httpResponse);
                }
                catch (UnauthorizedException)
                {
                    _credentials.ResetAccessToken();
                    using (var retryClient = new HttpClient(await GetHandlersAsync(headerParameters)))
                    {
                        httpResponse = await retryClient.DeleteAsyncWithRetryPolicy(builder.Uri);
                        return await HandleResponseAsync(httpResponse);
                    }
                }
            }
        }

        private async Task<DelegatingHandler> GetHandlersAsync(
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            if (_customHandler != null)
            {
                return _customHandler;
            }

            var mainHandler = await _credentials.GetHandlers();
            var headersHandler = new HeadersHandler(headerParameters);
            var userAgentHandler = new UserAgentHandler();
            headersHandler.InnerHandler = userAgentHandler;
            if (mainHandler.InnerHandler != null)
            {
                userAgentHandler.InnerHandler = mainHandler.InnerHandler;
            }

            mainHandler.InnerHandler = headersHandler;
            return mainHandler;
        }

        private static async Task<dynamic> HandleResponseAsync(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<dynamic>(await httpResponse.Content.ReadAsStringAsync());
            }
            else
            {
                await SdkException.GenerateSdkExceptionAsync(httpResponse);
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