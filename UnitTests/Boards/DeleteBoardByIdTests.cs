using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class DeleteBoardByIdTests
    {
        [Fact]
        public void DeleteBoardsByIdBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DeleteBoardsById().WithBoardId("15345").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345");
        }
    }
}
