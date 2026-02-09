using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Customers;

public class CustomersTests
{
    [Fact]
    public async Task GetCustomerInfoBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient
            .GetApiClientWithResourceOwnerCredentials("apiKey", "apiSecret", "userName", "userPassword", testHandler)
            .Customers()
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("/customers/current");
    }
}
