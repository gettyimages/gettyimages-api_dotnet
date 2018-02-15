using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Events
{
    public class EventsTests
    {
        [Fact]
        public void MultipleEventsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Events().WithIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=518451%2C518452");
        }

        [Fact]
        public void SingleEventBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Events().WithId(518451).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events/518451");
        }

        [Fact]
        public void MultileEventsWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            var fields = new List<string>() { "id", "image_count" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Events().WithIds(ids).WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=518451%2C518452");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=id%2Cimage_count");
        }

        [Fact]
        public void SingleEventWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "id", "image_count" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Events().WithId(518451).WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("events/518451");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=id%2Cimage_count");
        }

    }
}
