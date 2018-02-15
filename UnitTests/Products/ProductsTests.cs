using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Products
{
    public class CountriesTests
    {
        [Fact]
        public void ProductsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Products()
                .ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("products");
        }

        [Fact]
        public void ProductsWithResponseField()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "download_requirements" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Products()
                .WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("products");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=download_requirements");
        }
    }
}
