using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Downloads
{
    public class DownloadsTests
    {

        [Fact]
        public void DownloadsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads().ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        }

        [Fact]
        public void DownloadsWithCompanyDownloads()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads().WithCompanyDownloads().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("company_downloads=True");
        }

        [Fact]
        public void DownloadsWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads().WithEndDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public void DownloadsWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads()
                .WithPage(2).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public void DownloadsWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads()
                .WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void DownloadsWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads()
                .WithProductType(ProductType.Easyaccess).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_type=easyaccess");
        }


        [Fact]
        public void DownloadsWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads()
                .WithStartDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
} 
