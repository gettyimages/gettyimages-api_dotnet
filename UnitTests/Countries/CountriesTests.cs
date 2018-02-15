using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Countries
{
    public class CollectionsTests
    {
        [Fact]
        public void CountriesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Countries()
                .ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("countries");
        }
    }
}
