using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Images;

public class ImagesSimilarTests
{
    [Fact]
    public async Task ImagesSimilarBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .ImagesSimilar().WithId("882449540").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/similar");
    }


    [Fact]
    public async Task ImagesSimilarWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .ImagesSimilar().WithId("882449540").WithPage(3).ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/similar");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task ImagesSimilarWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .ImagesSimilar().WithId("882449540").WithPageSize(50).ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/similar");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }
}
