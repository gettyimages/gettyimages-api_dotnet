using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Videos
{
    public class VideosDownloadHistoryTests
    {
        [Fact]
        public void ImageDownloadHistoryWithCompanyDownloads()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
               .VideoDownloadHistory().WithId("882449540").WithCompanyDownloads().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/downloadhistory");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("company_downloads=True");
        }

        [Fact]
        public void DownloadHistoryForImage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
               .VideoDownloadHistory().WithId("882449540").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/downloadhistory");
        }
    }
}
