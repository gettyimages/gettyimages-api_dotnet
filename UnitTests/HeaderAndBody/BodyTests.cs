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
        public void BodyBuilderTest()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var assets = @"[
             {
                'asset_id': 'string'
             }
             ]";

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PutAssets().WithBoardId("15345").WithBoardAssets(assets).ExecuteAsync().Result;

            Assert.Equal("application/json", testHandler.Request.Content.Headers.ContentType.ToString());
        }
    }
}
