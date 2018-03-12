using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges
{
    public class ChangeSetsTests
    {
        [Fact]
        public void ChangeSetsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .ChangeSets().WithChannelId(155432).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("channel_id=155432");
        }

        public void ChangeSetsWithBatchSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ChangeSets()
                .WithChannelId(155432).WithBatchSize(200).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("batch_size=155432");
        }
    }
}
