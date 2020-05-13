using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchVideosTests
    {
        [Fact]
        public async Task SearchForBlendedVideosWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await  ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithDownloadProduct()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
               .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithEditorialVideoType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithEditorialVideoType(EditorialVideo.Raw | EditorialVideo.Produced).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_video_types=raw%2Cproduced");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithFormatFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithAvailableFormat("HD").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithFrameRates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithLicenseModel()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithLicenseModel(LicenseModel.RightsReady | LicenseModel.RoyaltyFree).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("license_models=royaltyfree%2Crightsready");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithPage(2).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .SearchVideos()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public async Task SearchForBlendedVideosWithSpecificPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var people = new List<string>() { "Reggie Jackson" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
        }

        [Fact]
        public async Task SearchForVideosWithReleaseStatus()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
                .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.FullyReleased).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=fully_released");
        }

        [Fact]
        public async Task SearchForVideosWithMinimumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
        }

        [Fact]
        public async Task SearchForVideosWithMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
               .WithPhrase("cat").WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }

        [Fact]
        public async Task SearchForVideosWithMinimumAndMaximumClipLength()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideos()
               .WithPhrase("cat").WithMinimumVideoClipLength(20).WithMaximumVideoClipLength(200).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
        }
    }
}
