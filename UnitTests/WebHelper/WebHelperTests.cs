using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api;
using Xunit;

namespace UnitTests.WebHelper;

public class WebHelperTests
{
    [Fact]
    public async Task Check500CodeTest()
    {
        var httpResponse = new HttpResponseMessage();
        httpResponse.StatusCode = (HttpStatusCode)500;
        var testHandler = new TestHandler(httpResponse);
        var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchImagesCreative().WithPhrase("cat");
        var ex = await Assert.ThrowsAsync<SdkException>(async () => await response.ExecuteAsync());
        Assert.True(testHandler.NumberOfCallsSendAsync >= 2);
    }
}