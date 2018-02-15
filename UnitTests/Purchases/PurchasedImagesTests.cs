using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Purchases
{
    public class PurchasedImagesTests
    {
        [Fact]
        public void PurchasedImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
        }

        [Fact]
        public void PurchasedImagesWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithEndDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public void PurchasedImagesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithPage(3).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public void PurchasedImagesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void PurchasedImagesWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PurchasedImages().WithStartDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
}
