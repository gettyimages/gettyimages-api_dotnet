using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Events;

public class EventsTests
{
    [Fact]
    public async Task MultipleEventsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 518451, 518452 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Events()
            .WithIds(ids)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=518451%2C518452");
    }

    [Fact]
    public async Task SingleEventBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Events()
            .WithId(518451)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events/518451");
    }

    [Fact]
    public async Task MultipleEventsWithResponseFields()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 518451, 518452 };

        var fields = new List<string> { "id", "image_count" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Events()
            .WithIds(ids)
            .WithResponseFields(fields)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=518451%2C518452");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=id%2Cimage_count");
    }

    [Fact]
    public async Task SingleEventWithResponseFields()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var fields = new List<string> { "id", "image_count" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Events()
            .WithId(518451)
            .WithResponseFields(fields)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events/518451");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=id%2Cimage_count");
    }
}