using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Purchases
{
    public class PurchasedImagesTests
    {
        [Fact]
        public async Task PurchasedImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
        }

        [Fact]
        public async Task PurchasedImagesWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithEndDate("2015-04-01").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public async Task PurchasedImagesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithPage(3).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public async Task PurchasedImagesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task PurchasedImagesWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithStartDate("2015-04-01").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
}
