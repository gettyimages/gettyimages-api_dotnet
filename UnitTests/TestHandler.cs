using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnitTests
{

    public class TestHandler : DelegatingHandler
    {
        private readonly HttpResponseMessage _httpResponseMessage;

        public TestHandler(object testResponse)
        {
            _httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(testResponse))
            };
        }

        public TestHandler(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
        }
        public HttpRequestMessage Request { get; private set; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Request = request;
            return Task.FromResult(_httpResponseMessage);
        }
    }
}
