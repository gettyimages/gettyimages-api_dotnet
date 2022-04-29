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
}