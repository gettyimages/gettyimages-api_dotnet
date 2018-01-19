using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class GetBoardsByIdTests
    {
        [Fact]
        public void GetBoardsByIdBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .GetBoardsById().WithBoardId("15345").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345");
        }
    }
}
