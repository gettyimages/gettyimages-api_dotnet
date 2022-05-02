using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges;

public class DeleteAssetChangesTests
{
    [Fact]
    public async Task DeleteAssetChangesBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DeleteAssetChanges().WithChangeSetId(155432).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets/155432");
    }
}