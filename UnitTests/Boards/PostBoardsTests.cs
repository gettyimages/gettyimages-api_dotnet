using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class PostBoardsTests
    {
        [Fact]
        public void PostBoardsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var newboard = @"{
                'name': 'string',
                'description': 'string'
            }";
            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PostBoards().WithNewBoard(newboard).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        }
    }
}
