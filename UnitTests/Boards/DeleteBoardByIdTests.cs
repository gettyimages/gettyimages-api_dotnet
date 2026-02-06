using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Boards;

public class DeleteBoardByIdTests
{
    [Fact]
    public async Task DeleteBoardsByIdBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DeleteBoardsById().WithBoardId("15345").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345");
    }
}
