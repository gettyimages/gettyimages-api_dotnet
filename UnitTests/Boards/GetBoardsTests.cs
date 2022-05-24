using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Boards;

public class GetBoardsTests
{
    [Fact]
    public async Task GetBoardsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetBoards().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
    }

    [Fact]
    public async Task GetBoardsWithBoardRelationship()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetBoards().WithBoardRelationship(BoardRelationship.Invited).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("board_relationship=invited");
    }

    [Fact]
    public async Task GetBoardsWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetBoards().WithPage(3).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task GetBoardsWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetBoards().WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }

    [Fact]
    public async Task GetBoardsWithSortOrder()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetBoards().WithSortOrder(SortOrderEditorial.BestMatch).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("boards");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
    }
}