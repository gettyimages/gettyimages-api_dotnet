using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchVideosCreativeTests
    {
        [Fact]
        public void SearchForCreativeVideosWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public void SearchForCreativeVideosWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public void SearchForCreativeVideosWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public void SearchForCreativeVideosWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public void SearchForCreativeVideosWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public void SearchForCreativeVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public void SearchForCreativeVideosWithFormatFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithAvailableFormat("HD").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
        }

        [Fact]
        public void SearchForCreativeVideosWithFrameRates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
        }

        [Fact]
        public void SearchForCreativeVideosWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public void SearchForCreativeVideosWithLicenseModel()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithLicenseModel(LicenseModel.RightsReady | LicenseModel.RoyaltyFree).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("license_models=royaltyfree%2Crightsready");
        }

        [Fact]
        public void SearchForCreativeVideosWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithPage(2).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public void SearchForCreativeVideosWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void SearchForCreativeVideosWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }

        [Fact]
        public void SearchForCreativeVideosWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public void SearchForCreativeVideosWithReleaseStatus()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.ReleaseNotImportant).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=release_not_important");
        }

        [Fact]
        public void SearchForCreativeVideosWithMinimumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
        }

        [Fact]
        public void SearchForCreativeVideosWithMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMaximumVideoClipLength(200).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }

        [Fact]
        public void SearchForCreativeVideosWithMinimumAndMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).WithMaximumVideoClipLength(200).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }
    }
}
