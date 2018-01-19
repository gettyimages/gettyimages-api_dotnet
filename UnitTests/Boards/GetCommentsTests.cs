using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class GetCommentsTests
    {
        [Fact]
        public void GetCommentsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .GetComments().WithBoardId("15345").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments");
        }
    }
}
