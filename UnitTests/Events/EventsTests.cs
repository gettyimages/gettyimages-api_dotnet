using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
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
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=518451");
    }
}