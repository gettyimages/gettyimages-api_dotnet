using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards
{
    public class PostCommentsTests
    {
        [Fact]
        public void PostCommentsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var comment = @"{
                'text': 'string'
             }";

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .PostComments().WithBoardId("15345").WithComment(comment).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments");
        }
    }
}
