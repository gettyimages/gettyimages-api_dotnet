using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Downloads
{
    public class DownloadImagesTests
    {

        [Fact]
        public void DownloadImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
        }

        [Fact]
        public void DownloadImagesWithAutoDownload()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").WithAutoDownload().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("auto_download=True");
        }

        [Fact]
        public void DownloadImagesWithFileType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").WithFileType(FileType.Jpg).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_type=jpg");
        }

        [Fact]
        public void DownloadImagesWithHeight()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").WithHeight(592).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("height=592");
        }

        [Fact]
        public void DownloadImagesProductId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").WithProductId(592).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_id=592");
        }

        [Fact]
        public void DownloadImagesWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).DownloadsImages().WithId("464423888").WithProductType(ProductType.Easyaccess).WithHeight(592).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_type=easyaccess");
        }
    }
} 
