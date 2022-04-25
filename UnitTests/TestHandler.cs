using System.IO;
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
        public int NumberOfCallsSendAsync = 0;

        public TestHandler(object testResponse)
        {
            var stream = new MemoryStream();
            System.Text.Json.JsonSerializer.Serialize(stream, testResponse);
            _httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                
                Content = new StreamContent(stream)
            };
            stream.Seek(0, SeekOrigin.Begin);
        }

        public TestHandler(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
        }
        public HttpRequestMessage Request { get; private set; }
        public Stream RequestStream { get; set; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await request.Content.LoadIntoBufferAsync();
            RequestStream = await request.Content.ReadAsStreamAsync(cancellationToken);
            RequestStream.Seek(0, SeekOrigin.Begin);
            
            NumberOfCallsSendAsync += 1;
            Request = request;
            return _httpResponseMessage;
        }
    }
}
