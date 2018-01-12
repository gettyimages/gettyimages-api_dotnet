using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        internal async Task<dynamic> Get(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
            IEnumerable<KeyValuePair<string, string>> headerParameters = null)
        {
            using (var client = new HttpClient(await GetHandlers(headerParameters)))
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
                    using (var retryClient = new HttpClient(await GetHandlers(headerParameters)))
                    {
                        httpResponse = await retryClient.GetAsync(builder.Uri);
                        return await HandleResponse(httpResponse);
                    }
                }
            }
        }

        private async Task<DelegatingHandler> GetHandlers(
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

        internal async Task<dynamic> PostForm(IEnumerable<KeyValuePair<string, string>> formParameters, string path)
        {
            var handlers = await GetHandlers();
            return PostForm(formParameters, path, handlers);
        }

        internal async Task<dynamic> PostForm(
            IEnumerable<KeyValuePair<string, string>> formParameters,
            string path, DelegatingHandler handlers, IEnumerable<KeyValuePair<string, string>> headerParameters = null, bool shouldRetry = true)
        {
            using (var client = new HttpClient(handlers == null
                        ? new UserAgentHandler()
                        : handlers))
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
                        using (var retryClient = new HttpClient(await GetHandlers(headerParameters)))
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
            using (var client = new HttpClient(await GetHandlers(headerParameters)))
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
                    using (var retryClient = new HttpClient(await GetHandlers(headerParameters)))
                    {
                        httpResponse = await retryClient.PostAsync(uri, new FormUrlEncodedContent(queryParameters));
                        return await HandleResponse(httpResponse);
                    }
                }
            }
        }

        private static async Task<dynamic> HandleResponse(HttpResponseMessage httpResponse)
        {
            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<dynamic>(await httpResponse.Content.ReadAsStringAsync());
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