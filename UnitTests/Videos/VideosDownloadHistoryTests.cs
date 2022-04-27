using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Videos;

public class VideosDownloadHistoryTests
{
    [Fact]
    public async Task ImageDownloadHistoryWithCompanyDownloads()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .VideoDownloadHistory()
            .WithId("882449540")
            .WithCompanyDownloads()
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/downloadhistory");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("company_downloads=True");
    }

    [Fact]
    public async Task DownloadHistoryForImage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .VideoDownloadHistory()
            .WithId("882449540")
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/downloadhistory");
    }
}