using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges
{
    public class ChannelsTests
    {
        [Fact]
        public async Task ChannelsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Channels().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/channels");
        }
    }
}
