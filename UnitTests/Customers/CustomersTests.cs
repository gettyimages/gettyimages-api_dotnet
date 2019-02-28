using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Customers
{
    public class CustomersTests
    {
        [Fact]
        public void GetCustomerInfoBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithResourceOwnerCredentials("apiKey", "apiSecret", "userName", "userPassword", testHandler)
                                    .Customers()
                                    .ExecuteAsync()
                                    .Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("/customers/current");
        }
    }
}
