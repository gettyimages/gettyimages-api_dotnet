using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GettyImages.Api
{
    public class SdkException : Exception
    {
        private const string ErrorMessageProperty1 = "ErrorMessage";
        private const string ErrorMessageProperty2 = "error_message";

        internal SdkException(string message, HttpStatusCode? statusCode = null) : base(message)
        {
            StatusCode = statusCode;
        }

        internal SdkException(string message, Exception innerException, HttpStatusCode? statusCode = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode? StatusCode { get; set; }

        internal static async Task GenerateSdkExceptionAsync(HttpResponseMessage httpResponse, string message = null)
        {
            if (httpResponse.Content != null && string.IsNullOrEmpty(message))
            {
                var resultContentAsString = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.Content.Headers != null && httpResponse.Content.Headers.ContentType != null && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                {   
                    var response = JObject.Parse(resultContentAsString);
                    JToken errorMessage;
                    if (response.TryGetValue(ErrorMessageProperty1, out errorMessage) ||
                        response.TryGetValue(ErrorMessageProperty2, out errorMessage))
                    {
                        message = errorMessage.Value<string>();
                    }
                }
                else
                {
                    message = resultContentAsString;
                }
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
}