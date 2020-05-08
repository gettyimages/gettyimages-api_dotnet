using System.Threading.Tasks;
using GettyImages.Api;
using GettyImages.Api.Boards;
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

            postBoards.WithNewBoard(newboard);

            Assert.Equal(@"{
                'name': 'Test Board',
                'description': 'This board is for integration tests'
            }", postBoards.BodyParameter);
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
