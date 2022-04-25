using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.AssetChanges
{
    public class ChannelsTests
    {
        [Fact]
        public async Task ChannelsBasic()
        {
            var channels = new Channel[]
            {
                new Channel()
            };

            var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, channels);
            var content = new StreamContent(stream);
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = content;
            responseMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                
            var testHandler = new TestHandler(responseMessage);

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Channels().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/channels");
        }
    }
}
