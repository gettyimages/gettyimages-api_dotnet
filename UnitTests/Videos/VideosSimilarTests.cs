using System.Diagnostics;
using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Videos;

public class VideosSimilarTests
{
    [Fact]
    public async Task VideosSimilarBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .VideosSimilar()
            .WithId("882449540")
            .ExecuteAsync();

        Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
    }


    [Fact]
    public async Task VideosSimilarWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .VideosSimilar().WithId("882449540").WithPage(3).ExecuteAsync();

        Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task VideosSimilarWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .VideosSimilar().WithId("882449540").WithPageSize(50).ExecuteAsync();

        Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }
}
