using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Boards;

public class PutAssetsByIdTests
{
    [Fact]
    public async Task PutAssetsByIdBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PutAssetsById().WithBoardId("15345").WithAssetId("1245").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/assets/1245");
    }
}
