using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace GettyImages.Api
{
    internal static class PollyHttpClientExtensions
    {
        private static readonly AsyncRetryPolicy<HttpResponseMessage> RetryPolicy;

        static PollyHttpClientExtensions()
        {
            RetryPolicy =
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(responseMessage => (int) responseMessage.StatusCode == 429)
                    .WaitAndRetryAsync(3, retryAttempt =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    );
        }

        public static Task<HttpResponseMessage> GetAsyncWithRetryPolicy(this HttpClient httpClient, Uri uri)
        {
            return RetryPolicy.ExecuteAsync(() => httpClient.GetAsync(uri));
        }
        
        public static Task<HttpResponseMessage> PostAsyncWithRetryPolicy(this HttpClient httpClient, 
            string requestUri, HttpContent content)
        {
            return RetryPolicy.ExecuteAsync(() => httpClient.PostAsync(requestUri, content));
        }
        
        public static Task<HttpResponseMessage> PostAsyncWithRetryPolicy(this HttpClient httpClient, 
            Uri requestUri, HttpContent content)
        {
            return RetryPolicy.ExecuteAsync(() => httpClient.PostAsync(requestUri, content));
        }
        
        public static Task<HttpResponseMessage> PutAsyncWithRetryPolicy(this HttpClient httpClient, 
            Uri requestUri, HttpContent content)
        {
            return RetryPolicy.ExecuteAsync(() => httpClient.PutAsync(requestUri, content));
        }
        
        public static Task<HttpResponseMessage> DeleteAsyncWithRetryPolicy(this HttpClient httpClient, 
            Uri requestUri)
        {
            return RetryPolicy.ExecuteAsync(() => httpClient.DeleteAsync(requestUri));
        }
    }
}
