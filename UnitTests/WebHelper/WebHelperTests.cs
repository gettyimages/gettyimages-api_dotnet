using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api;
using Xunit;

namespace UnitTests
{
    public class WebHelperTests
    {
        [Fact]
        public async Task Check500CodeTest()
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = (HttpStatusCode) 500;

            var testHandler = new TestHandler(httpResponse);

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .SearchImages().WithPhrase("cat");

            var ex = await Assert.ThrowsAsync<NullReferenceException>(async () => await response.ExecuteAsync());

            Assert.Equal("Object reference not set to an instance of an object.", ex.Message);

            Assert.True(testHandler.NumberOfCallsSendAsync >= 2);
        }
    }
}