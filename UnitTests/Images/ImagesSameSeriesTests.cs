using FluentAssertions;
using GettyImages.Api;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Images
{
    public class ImagesSameSeriesTests
    {
        [Fact]
        public async Task ImagesSameSeriesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();
            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .ImagesSameSeries().WithId("882449540").ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/same-series");
        }


        [Fact]
        public async Task ImagesSameSeriesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();
            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .ImagesSameSeries().WithId("882449540").WithPage(3).ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/same-series");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public async Task ImagesSameSeriesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();
            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .ImagesSameSeries().WithId("882449540").WithPageSize(50).ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540/same-series");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }
    }
}
