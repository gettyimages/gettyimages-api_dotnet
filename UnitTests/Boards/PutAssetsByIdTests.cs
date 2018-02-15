using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class PutAssetsByIdTests
    {
        [Fact]
        public void PutAssetsByIdBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PutAssetsById().WithBoardId("15345").WithAssetId("1245").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets/1245");
        }
    }
}
