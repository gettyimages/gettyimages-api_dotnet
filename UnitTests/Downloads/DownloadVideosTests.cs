using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Downloads;

public class DownloadVideosTests
{
    [Fact]
    public async Task DownloadVideosBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DownloadsVideos()
            .WithId("681332124")
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
    }

    [Fact]
    public async Task DownloadVideosProductId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DownloadsVideos()
            .WithId("681332124")
            .WithProductId(592)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_id=592");
    }

    [Fact]
    public async Task DownloadVideosWithSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DownloadsVideos()
            .WithId("681332124")
            .WithSize("hd1")
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("size=hd1");
    }
}