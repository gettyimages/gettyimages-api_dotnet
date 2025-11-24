using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Orders;

public class OrdersTests
{
    [Fact]
    public async Task OrdersBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Orders().WithId(1234).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orders/1234");
    }
}