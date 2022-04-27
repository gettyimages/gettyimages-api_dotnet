using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class GetCommentsTests
{
    [Fact]
    public async Task GetCommentsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetComments().WithBoardId("15345").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345/comments");
    }
}