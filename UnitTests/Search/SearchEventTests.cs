using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Search;

public class SearchEventTests
{
    [Fact]
    public async Task SearchForEventsWithPhrase()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchEvents()
            .WithPhrase("cat")
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEventsWithDateFrom()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchEvents()
            .WithPhrase("cat")
            .WithDateFrom("2015-04-01")
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("date_from=2015-04-01");
    }

    [Fact]
    public async Task SearchForEventsWithDateTo()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchEvents()
            .WithPhrase("cat")
            .WithDateTo("2015-04-01")
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("date_to=2015-04-01");
    }

    [Fact]
    public async Task SearchForEventsWithEditorialSegment()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchEvents()
            .WithPhrase("cat")
            .WithEditorialSegment(EditorialSegment.Archival)
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_segment=archival");
    }

    [Fact]
    public async Task SearchForEventsWithResponseFields()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEventsWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
            .WithPhrase("cat").WithPage(2).ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
    }

    [Fact]
    public async Task SearchForEventsWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
            .WithPhrase("cat").WithPageSize(50).ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }
}