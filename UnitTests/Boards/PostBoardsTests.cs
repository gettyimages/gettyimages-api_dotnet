using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class PostBoardsTests
    {
        [Fact]
        public async Task PostBoardsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var newboard = @"{
                'name': 'string',
                'description': 'string'
            }";
            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PostBoards().WithNewBoard(newboard).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        }
    }
}
