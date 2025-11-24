using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges;

public class ChangeSetsTests
{
    [Fact]
    public async Task ChangeSetsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .ChangeSets().WithChannelId(155432).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("channel_id=155432");
    }

    [Fact]
    public async Task ChangeSetsWithBatchSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ChangeSets()
            .WithChannelId(155432).WithBatchSize(200).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("batch_size=200");
    }
}