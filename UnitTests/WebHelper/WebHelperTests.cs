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
        public void Check500CodeTest()
        {
            var httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = (HttpStatusCode) 500;

            var testHandler = new TestHandler(httpResponse);

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .SearchImages().WithPhrase("cat");

            Task<NullReferenceException> ex = Assert.ThrowsAsync<NullReferenceException>(async () => await response.ExecuteAsync());

            Assert.Equal("Object reference not set to an instance of an object.", ex.Result.Message);

            Assert.True(testHandler.NumberOfCallsSendAsync >= 2);
        }
    }
}
