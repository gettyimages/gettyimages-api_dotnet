using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchEventTests
    {
        [Fact]
        public void SearchForEventsWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public void SearchForEventsWithDateFrom()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithDateFrom("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("date_from=2015-04-01");
        }

        [Fact]
        public void SearchForEventsWithDateTo()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithDateTo("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("date_to=2015-04-01");
        }

        [Fact]
        public void SearchForEventsWithEditorialSegment()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithEditorialSegment(EditorialSegment.Archival).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_segments=archival");
        }

        [Fact]
        public void SearchForEventsWithReponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "id", "keywords" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=id%2Ckeywords");
        }

        [Fact]
        public void SearchForEventsWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithPage(2).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public void SearchForEventsWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchEvents()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/events");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }
    }
}
