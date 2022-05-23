using FluentAssertions;
using GettyImages.Api;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Videos
{
    public class VideosSameSeriesTests
    {

        [Fact]
        public async Task VideosSameSeriesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSameSeries()
                .WithId("882449540")
                .ExecuteAsync();

            Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/same-series");
        }


        [Fact]
        public async Task VideosSameSeriesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSameSeries().WithId("882449540").WithPage(3).ExecuteAsync();

            Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/same-series");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public async Task VideosSameSeriesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSameSeries().WithId("882449540").WithPageSize(50).ExecuteAsync();

            Debug.Assert(testHandler.Request.RequestUri != null, "testHandler.Request.RequestUri != null");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/same-series");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }
    }
}
