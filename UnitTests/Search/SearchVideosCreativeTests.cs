using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchVideosCreativeTests
    {
        [Fact]
        public async Task SearchForCreativeVideosWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithDownloadProduct()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithFormatFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithAvailableFormat("HD").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithFrameRates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithLicenseModel()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithLicenseModel(LicenseModel.RightsReady | LicenseModel.RoyaltyFree).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("license_models=royaltyfree%2Crightsready");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithPage(2).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithReleaseStatus()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
                .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.ReleaseNotImportant).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=release_not_important");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithMinimumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }

        [Fact]
        public async Task SearchForCreativeVideosWithMinimumAndMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }
    }
}
