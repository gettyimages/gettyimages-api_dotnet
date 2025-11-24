using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class PostCommentsTests
{
    [Fact]
    public async Task PostCommentsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var comment = @"{
                'text': 'string'
             }";

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PostComments().WithBoardId("15345").WithComment(comment).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments");
    }
}