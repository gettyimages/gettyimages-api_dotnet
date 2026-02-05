using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class DeleteAssetsByIdTests
{
    [Fact]
    public async Task DeleteAssetsByIdBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DeleteAssetsById().WithBoardId("15345").WithAssetId("1245").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets/1245");
    }
}