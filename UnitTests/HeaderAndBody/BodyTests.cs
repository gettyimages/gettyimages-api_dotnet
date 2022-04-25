using System.Threading.Tasks;
using GettyImages.Api;
using GettyImages.Api.Boards;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.HeaderAndBody
{
    public class BodyTests
    {
        [Fact]
        public void BodyParameterTest()
        {
            var postBoards = PostBoards.GetInstance(null, null, null);

            var newboard = @"{
                'name': 'Test Board',
                'description': 'This board is for integration tests'
            }";

            postBoards.WithNewBoard(new BoardInfo
            {
                Name = "Test Board",
                Description = "This board is for integration tests"
            });

            Assert.Equal(@"{
                'name': 'Test Board',
                'description': 'This board is for integration tests'
            }", postBoards.StringBodyParameter);
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
}
