using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Videos
{
    public class VideosTests
    {
        [Fact]
        public async Task MultipleVideosBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
        }

        [Fact]
        public async Task SingleVideoBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithId("882449540").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540");
        }

        [Fact]
        public async Task MultipleVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() {"882449540", "629219532"};

            var fields = new List<string>() { "country", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithIds(ids).WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }

        [Fact]
        public async Task SingleVideoWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "country", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Videos().WithId("882449540").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("videos/882449540");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }
    }
}
