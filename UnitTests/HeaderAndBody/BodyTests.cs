using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;
using GettyImages.Api.Boards;
using GettyImages.Api.Models;

using Xunit;

namespace UnitTests.HeaderAndBody;

public class BodyTests
{
    [Fact]
    public void BodyParameterTest()
    {
        var postBoards = PostBoards.GetInstance(null, null, null);

        var description = "This board is for integration tests";
        var name = "Test Board";
        postBoards.WithNewBoard(new BoardInfo
        {
            Name = name,
            Description = description
        });

        ((BoardInfo)postBoards.BodyParameter).Description.Should().Be(description);
        ((BoardInfo)postBoards.BodyParameter).Name.Should().Be(name);
    }

    [Fact]
    public async Task BodyBuilderTest()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var assets = @"[
             {
                'asset_id': 'string'
             }
             ]";

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PutAssets().WithBoardId("15345").WithBoardAssets(assets).ExecuteAsync();

        Assert.Equal("application/json", testHandler.Request.Content.Headers.ContentType.ToString());
    }
}
