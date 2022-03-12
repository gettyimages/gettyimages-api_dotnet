using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Search;

public class SearchImagesCreativeByImageTests
{
    [Fact]
    public async Task SearchForCreativeImagesWithUrl()
    {
        var testHandler = TestUtil.CreateTestHandler();
        var unitUnderTest = ApiClient.GetApiClientWithClientCredentials("apiKey",
                "apiSecret",
                testHandler)
            .SearchImagesCreativeByImage();
        await unitUnderTest
            .AddToBucketAndSearchAsync("test-image.jpg");
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .StartWith("https://api.gettyimages.com/v3/search/by-image/uploads");

        await unitUnderTest.ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .StartWith("https://api.gettyimages.com/v3/search/images/creative/by-image");
    }
}