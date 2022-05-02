using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class PutAssetsTests
{
    [Fact]
    public async Task PutAssetsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var assets = @"[
             {
                'asset_id': 'string'
             }
             ]";
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PutAssets().WithBoardId("15345").WithBoardAssets(assets).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets");
    }
}