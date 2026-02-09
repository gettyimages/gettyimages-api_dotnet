using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api;

public class SdkException : Exception
{
    internal SdkException(string message, HttpStatusCode? statusCode = null) : base(message)
    {
        StatusCode = statusCode;
    }

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public HttpStatusCode? StatusCode { get; }

    internal static async Task GenerateSdkExceptionAsync(HttpResponseMessage httpResponse, string message = null)
    {
        if (httpResponse.Content != null && string.IsNullOrEmpty(message))
        {
            message = await httpResponse.Content.ReadAsStringAsync();
        }

        if (string.IsNullOrEmpty(message))
        {
            message = $"{(int)httpResponse.StatusCode} - {httpResponse.ReasonPhrase}";
        }

        switch (httpResponse.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                throw new UnauthorizedException(message);
            default:
                throw new SdkException(message, httpResponse.StatusCode);
        }
    }
}
