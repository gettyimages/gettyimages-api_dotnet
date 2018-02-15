using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Videos
{
    public class VideosTests
    {
        [Fact]
        public void MultipleVideosBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
        }

        [Fact]
        public void SingleVideoBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithId("882449540").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540");
        }

        [Fact]
        public void MultileVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() {"882449540", "629219532"};

            var fields = new List<string>() { "country", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithIds(ids).WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }

        [Fact]
        public void SingleVideoWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "country", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithId("882449540").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }
    }
}
