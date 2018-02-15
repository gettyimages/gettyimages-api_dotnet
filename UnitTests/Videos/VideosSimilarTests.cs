using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Videos
{
    public class VideosSimilarTests
    {
        [Fact]
        public void VideosSimilarBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSimilar().WithId("882449540").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
        }

        [Fact]
        public void VideosSimilarWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "country", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSimilar().WithId("882449540").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }

        [Fact]
        public void VideosSimilarWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSimilar().WithId("882449540").WithPage(3).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public void VideosSimilarWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .VideosSimilar().WithId("882449540").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540/similar");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }
    }
}
