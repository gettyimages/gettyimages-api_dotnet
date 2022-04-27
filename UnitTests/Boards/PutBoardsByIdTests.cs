using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Boards;

public class PutBoardsByIdTests
{
    [Fact]
    public async Task PutBoardsByIdBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PutBoardsById().WithBoardId("15345").ExecuteVoidAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards/15345");
    }
}