using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class DeleteCommentsByIdTests
    {
        [Fact]
        public void DeleteCommentsByIdBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DeleteCommentsById().WithBoardId("15345").WithCommentId("1245").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments/1245");
        }
    }
}
