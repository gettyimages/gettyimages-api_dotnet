using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class PutAssetsTests
    {
        [Fact]
        public void PutAssetsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var assets = @"[
             {
                'asset_id': 'string'
             }
             ]";
            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PutAssets().WithBoardId("15345").WithBoardAssets(assets).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets");
        }
    }
}
