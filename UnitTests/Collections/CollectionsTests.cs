using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Collections
{
    public class CollectionsTests
    {
        [Fact]
        public void CollectionsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Collections()
                .ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections");
        }
    }
}
