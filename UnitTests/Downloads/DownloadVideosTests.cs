using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Downloads
{
    public class DownloadVideosTests
    {

        [Fact]
        public void DownloadVideosBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsVideos()
                .WithId("681332124").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
        }

        [Fact]
        public void DownloadVidoesWithAutoDownload()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsVideos().WithId("464423888").WithAutoDownload().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("auto_download=True");
        }

        [Fact]
        public void DownloadVideosProductId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsVideos().WithId("681332124").WithProductId(592).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_id=592");
        }

        [Fact]
        public void DownloadVideosWithSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsVideos()
                .WithId("681332124").WithSize("hd1").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/videos/681332124");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("size=hd1");
        }
    }
} 
