using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Products;

public class CountriesTests
{
    [Fact]
    public async Task ProductsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Products()
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("products");
    }

    [Fact]
    public async Task ProductsWithResponseField()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var fields = new List<string> { "download_requirements" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Products()
            .WithResponseFields(fields).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("products");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=download_requirements");
    }
}