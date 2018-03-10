using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class DeleteAssetsByIdTests
    {
        [Fact]
        public void DeleteAssetsByIdBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DeleteAssetsById().WithBoardId("15345").WithAssetId("1245").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets/1245");
        }
    }
}
