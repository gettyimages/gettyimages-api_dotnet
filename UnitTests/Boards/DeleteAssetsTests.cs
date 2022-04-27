using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class DeleteAssetsTests
{
    [Fact]
    public async Task DeleteAssetsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<string> { "1234", "12553" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DeleteAssets().WithBoardId("15345").WithAssetIds(ids).ExecuteVoidAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset_ids=1234%2C12553");
    }
}