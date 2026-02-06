using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Search;

public class SearchVideosCreativeByImageTests
{
    [Fact]
    public async Task SearchForCreativeVideosWithUrl()
    {
        var testHandler = TestUtil.CreateTestHandler();
        var unitUnderTest = ApiClient.GetApiClientWithClientCredentials("apiKey",
                "apiSecret",
                testHandler)
            .SearchVideosCreativeByImage();
        await unitUnderTest
            .AddToBucketAndSearchAsync("test-image.jpg");
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .StartWith("https://api.gettyimages.com/v3/search/by-image/uploads");

        await unitUnderTest.ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .StartWith("https://api.gettyimages.com/v3/search/videos/creative/by-image");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithAssetId()
    {
        var testHandler = TestUtil.CreateTestHandler();
        var unitUnderTest = ApiClient.GetApiClientWithClientCredentials("apiKey",
                "apiSecret",
                testHandler)
            .SearchVideosCreativeByImage()
            .WithAssetId("681332124");

        await unitUnderTest.ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative/by-image");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset_id=681332124");
    }
}
