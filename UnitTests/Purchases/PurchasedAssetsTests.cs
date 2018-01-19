using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Purchases
{
    public class PurchasedAssetsTests
    {
        [Fact]
        public void PurchasedAssetsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        }

        [Fact]
        public void PurchasedAssetsWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithEndDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public void PurchasedAssetsWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithPage(3).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public void PurchasedAssetsWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void PurchasedAssetsWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedAssets().WithStartDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
}
