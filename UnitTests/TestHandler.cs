using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using GettyImages.Api;

namespace UnitTests;

public class TestHandler : DelegatingHandler
{
    private readonly HttpResponseMessage _httpResponseMessage;
    public int NumberOfCallsSendAsync;

    public TestHandler(object testResponse)
    {
        var stream = new MemoryStream();
        Serializer.SerializeAsync(stream, testResponse).Wait();
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

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.Content != null)
        {
            await request.Content.LoadIntoBufferAsync();
            RequestStream = await request.Content.ReadAsStreamAsync(cancellationToken);
            RequestStream.Seek(0, SeekOrigin.Begin);
        }

        NumberOfCallsSendAsync += 1;
        Request = request;
        return _httpResponseMessage;
    }
}
