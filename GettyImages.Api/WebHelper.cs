using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GettyImages.Api.Handlers;

namespace GettyImages.Api;

internal class WebHelper
{
    private readonly string _baseAddress;
    private readonly Credentials _credentials;
    private readonly DelegatingHandler _customHandler;

    internal WebHelper(Credentials credentials, string baseAddress, DelegatingHandler customHandler)
    {
        _credentials = credentials;
        _baseAddress = baseAddress;
        _customHandler = customHandler;
    }

    internal async Task GetAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var builder = new UriBuilder(uri)
        {
            Query =
                BuildQuery(queryParameters)
        };

        var httpResponse = await client.GetAsyncWithRetryPolicy(builder.Uri);

        try
        {
            await httpResponse.HandleResponseAsync();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.GetAsyncWithRetryPolicy(builder.Uri);
            await httpResponse.HandleResponseAsync();
        }
    }

    internal async Task<T> GetAsync<T>(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var builder = new UriBuilder(uri)
        {
            Query =
                BuildQuery(queryParameters)
        };

        var httpResponse = await client.GetAsyncWithRetryPolicy(builder.Uri);

        try
        {
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.GetAsyncWithRetryPolicy(builder.Uri);
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
    }

    internal async Task<T> PostFormAsync<T>(
        IEnumerable<KeyValuePair<string, string>> formParameters,
        string path, DelegatingHandler handlers, IEnumerable<KeyValuePair<string, string>> headerParameters = null,
        bool shouldRetry = true)
    {
        using var client = new HttpClient(handlers ?? new UserAgentHandler());
        var uri = _baseAddress + path;
        var formContent = new FormUrlEncodedContent(formParameters);

        var httpResponse = await client.PostAsyncWithRetryPolicy(uri, formContent);

        try
        {
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
        catch (UnauthorizedException)
        {
            if (shouldRetry)
            {
                _credentials.ResetAccessToken();
                using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
                httpResponse = await retryClient.PostAsyncWithRetryPolicy(uri, formContent);
                return await httpResponse.GetContentHandleResponseAsync<T>();
            }

            throw;
        }
    }

    internal async Task<HttpResponseMessage> GetRawHttpResponseMessageAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, CancellationToken cancellationToken = default)
    {
        return await RetryOnUnauthorizedAction(Action);

        async Task<HttpResponseMessage> Action()
        {
            using var client = new HttpClient(await GetHandlersAsync(headerParameters));
            var uri = _baseAddress + path;
            var builder = new UriBuilder(uri)
            {
                Query =
                    BuildQuery(queryParameters)
            };

            return await client.GetAsyncWithRetryPolicy(builder.Uri);
        }
    }

    internal async Task<HttpResponseMessage> PostQueryRawHttpResponseMessageAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter)
    {
        return await RetryOnUnauthorizedAction(Action);

        async Task<HttpResponseMessage> Action()
        {
            using var client = new HttpClient(await GetHandlersAsync(headerParameters));
            var uri = _baseAddress + path;
            var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

            return await client.PostAsyncWithRetryPolicy(requestUri, bodyParameter);
        }
    }

    internal async Task<HttpResponseMessage> PutQueryRawHttpResponseMessageAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter)
    {
        return await RetryOnUnauthorizedAction(Action);

        // TODO - DRY with PostQueryRawHttpResponseMessageAsync?  
        async Task<HttpResponseMessage> Action()
        {
            using var client = new HttpClient(await GetHandlersAsync(headerParameters));
            var uri = _baseAddress + path;
            var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

            return await client.PutAsyncWithRetryPolicy(requestUri, bodyParameter);
        }
    }

    private static async Task<HttpResponseMessage> RetryOnUnauthorizedAction(Func<Task<HttpResponseMessage>> action)
    {
        var httpResponse = await action();

        try
        {
            await httpResponse.HandleResponseAsync();
        }
        catch (UnauthorizedException)
        {
            httpResponse = await action();
            await httpResponse.HandleResponseAsync();
        }
        return httpResponse;
    }

    internal async Task PostQueryAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

        var httpResponse = await client.PostAsyncWithRetryPolicy(requestUri, bodyParameter);

        try
        {
            await httpResponse.HandleResponseAsync();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.PostAsyncWithRetryPolicy(requestUri, bodyParameter);
            await httpResponse.HandleResponseAsync();
        }
    }

    internal async Task<T> PostQueryAsync<T>(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

        var httpResponse = await client.PostAsyncWithRetryPolicy(requestUri, bodyParameter);

        try
        {
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.PostAsyncWithRetryPolicy(requestUri, bodyParameter);
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
    }

    internal async Task<T> PutQueryAsync<T>(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter,
        MediaTypeHeaderValue mediaType = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

        var httpResponse = await client.PutAsyncWithRetryPolicy(requestUri, bodyParameter);

        try
        {
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.PutAsyncWithRetryPolicy(requestUri, bodyParameter);
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
    }

    internal async Task PutQueryVoidAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters, HttpContent bodyParameter,
        MediaTypeHeaderValue mediaType = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var requestUri = new UriBuilder(uri) { Query = BuildQuery(queryParameters) }.Uri;

        var httpResponse = await client.PutAsyncWithRetryPolicy(requestUri, bodyParameter);

        try
        {
            await httpResponse.HandleResponseAsync();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.PutAsyncWithRetryPolicy(requestUri, bodyParameter);
            await httpResponse.HandleResponseAsync();
        }
    }

    internal async Task DeleteQueryVoidAsync(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var builder = new UriBuilder(uri)
        {
            Query =
                BuildQuery(queryParameters)
        };

        var httpResponse = await client.DeleteAsyncWithRetryPolicy(builder.Uri);

        try
        {
            await httpResponse.HandleResponseAsync();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.DeleteAsyncWithRetryPolicy(builder.Uri);
            await httpResponse.HandleResponseAsync();
        }
    }

    internal async Task<T> DeleteQueryAsync<T>(IEnumerable<KeyValuePair<string, string>> queryParameters, string path,
        IEnumerable<KeyValuePair<string, string>> headerParameters = null)
    {
        using var client = new HttpClient(await GetHandlersAsync(headerParameters));
        var uri = _baseAddress + path;
        var builder = new UriBuilder(uri)
        {
            Query =
                BuildQuery(queryParameters)
        };

        var httpResponse = await client.DeleteAsyncWithRetryPolicy(builder.Uri);

        try
        {
            return await httpResponse.GetContentHandleResponseAsync<T>();
        }
        catch (UnauthorizedException)
        {
            _credentials.ResetAccessToken();
            using var retryClient = new HttpClient(await GetHandlersAsync(headerParameters));
            httpResponse = await retryClient.DeleteAsyncWithRetryPolicy(builder.Uri);
            return await httpResponse.GetContentHandleResponseAsync<T>();
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

    private static string BuildQuery(IEnumerable<KeyValuePair<string, string>> queryParameters)
    {
        var keyValuePairs = queryParameters as KeyValuePair<string, string>[] ??
                            queryParameters.ToArray();
        return string.Join("&",
            keyValuePairs.Select(d => d.Key + "=" + WebUtility.UrlEncode(d.Value.ToString())));
    }
}