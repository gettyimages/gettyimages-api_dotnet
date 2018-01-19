using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges
{
    public class ChannelsTests
    {
        [Fact]
        public void ChannelsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Channels().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/channels");
        }
    }
}
