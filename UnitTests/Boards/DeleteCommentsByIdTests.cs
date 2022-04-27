using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class DeleteCommentsByIdTests
{
    [Fact]
    public async Task DeleteCommentsByIdBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DeleteCommentsById().WithBoardId("15345").WithCommentId("1245").ExecuteVoidAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments/1245");
    }
}