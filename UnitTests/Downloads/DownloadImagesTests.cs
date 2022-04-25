using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Downloads
{
    public class DownloadImagesTests
    {
        [Fact]
        public async Task DownloadImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DownloadsImages()
                .WithId("464423888")
                .ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
        }
        
        [Fact]
        public async Task DownloadImagesWithFileType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DownloadsImages()
                .WithId("464423888")
                .WithFileType(FileType.Jpg)
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_type=jpg");
        }

        [Fact]
        public async Task DownloadImagesWithHeight()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DownloadsImages()
                .WithId("464423888")
                .WithHeight(592)
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("height=592");
        }

        [Fact]
        public async Task DownloadImagesProductId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DownloadsImages()
                .WithId("464423888")
                .WithProductId(592)
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_id=592");
        }

        [Fact]
        public async Task DownloadImagesWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DownloadsImages()
                .WithId("464423888")
                .WithProductType(ProductType.Easyaccess)
                .WithHeight(592)
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads/images/464423888");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_type=easyaccess");
        }
    }
} 
