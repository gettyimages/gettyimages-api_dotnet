using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Purchases
{
    public class PurchasedAssetsTests
    {
        [Fact]
        public async Task PurchasedAssetsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        }

        [Fact]
        public async Task PurchasedAssetsWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithEndDate("2015-04-01").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public async Task PurchasedAssetsWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithPage(3).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public async Task PurchasedAssetsWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task PurchasedAssetsWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithStartDate("2015-04-01").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
}
