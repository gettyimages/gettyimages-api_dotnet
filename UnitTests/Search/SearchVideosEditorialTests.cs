using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchVideosEditorialTests
    {
        [Fact]
        public void SearchForEditorialVideosWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public void SearchForEditorialVideosWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public void SearchForEditorialVideosWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public void SearchForEditorialVideosWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public void SearchForEditorialVideosWithEditorialVideoType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithEditorialVideoType(EditorialVideo.Raw | EditorialVideo.Produced).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_video_types=raw%2Cproduced");
        }

        [Fact]
        public void SearchForEditorialVideosWithEntityUri()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var uris = new List<string>() { "example_uri_1", "example_uri_2" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithEntityUris(uris).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("entity_uris=example_uri_1%2Cexample_uri_2");
        }

        [Fact]
        public void SearchForEditorialVideosWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public void SearchForEditorialVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public void SearchForEditorialVideosWithFormatFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithAvailableFormat("HD").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
        }

        [Fact]
        public void SearchForEditorialVideosWithFrameRates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
        }

        [Fact]
        public void SearchForEditorialVideosWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }


        [Fact]
        public void SearchForEditorialVideosWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithPage(2).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public void SearchForEditorialVideosWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void SearchForEditorialVideosWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }


        [Fact]
        public void SearchForEditorialVideosWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public void SearchForEditorialVideosWithSpecificPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var people = new List<string>() { "Reggie Jackson" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
        }

        [Fact]
        public void SearchForEditorialVideosWithReleaseStatus()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
                .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.FullyReleased).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=fully_released");
        }

        [Fact]
        public void SearchForEditorialVideosWithMinimumDuration()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMinimumDuration(20).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_duration=20");
        }

        [Fact]
        public void SearchForEditorialVideosWithMaximumDuration()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMaximumDuration(200).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("maximum_duration=200");
        }

        [Fact]
        public void SearchForEditorialVideosWithMinimumAndMaximumDuration()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
               .WithPhrase("cat").WithMinimumDuration(20).WithMaximumDuration(200).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_duration=20");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("maximum_duration=200");
        }
    }
}
