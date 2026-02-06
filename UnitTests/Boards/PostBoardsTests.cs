using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;
using GettyImages.Api.Models;

using Xunit;

namespace UnitTests.Boards;

public class PostBoardsTests
{
    [Fact]
    public async Task PostBoardsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PostBoards().WithNewBoard(new BoardInfo()).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
    }
}
