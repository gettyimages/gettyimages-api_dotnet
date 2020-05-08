using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Collections
{
    public class CollectionsTests
    {
        [Fact]
        public async Task CollectionsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Collections()
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections");
        }
    }
}
