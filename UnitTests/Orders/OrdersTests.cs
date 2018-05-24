using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Orders
{
    public class OrdersTests
    {
        [Fact]
        public void OrdersBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Orders().WithId(1234).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orders/1234");
        }
    }
}
