using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Images
{
    public class ImagesTests
    {
        [Fact]
        public void MultipleImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
        }

        [Fact]
        public void SingleImageBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithId("882449540").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540");
        }

        [Fact]
        public void MultileImagesWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            var fields = new List<string>() { "country", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithIds(ids).WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }

        [Fact]
        public void SingleImageWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "country", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithId("882449540").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }
    }
}
