using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchImagesTests
    {
        [Fact]
        public async Task SearchForBlendedImagesWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await  ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .SearchImages()
                .WithPhrase("cat")
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithArtist()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var artists = new List<string>() { "roman makhmutov", "Linda Raymond" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithArtists(artists).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact] public async Task SearchForBlendedImagesWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithCollectionColor()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithColor("#002244").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("color=%23002244");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithComposition()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithDownloadProduct()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
               .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEmbedContentOnly()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEmbedContentOnly().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("embed_content_only=True");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEthnicity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEthnicity(Ethnicity.Black | Ethnicity.Japanese).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ethnicity=black%2Cjapanese");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEventIdsSingleId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEventIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEventIdsList()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEventIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEventIdsListChainedWithDuplicates()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEventIds(ids).WithEventIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEventIdsListChained()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            var ids2 = new List<int>() { 518453, 518454 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEventIds(ids).WithEventIds(ids2).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452%2C518453%2C518454");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithEventIdsArray()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new[] { 518451, 518452 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithEventIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id", "uri_oembed" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid%2Curi_oembed");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithFileTypes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithFileType(FileType.Eps | FileType.Jpg).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_types=eps%2Cjpg");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithGraphicalStyle()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Illustration).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cillustration");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithGraphicalStyleFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Vector).WithGraphicalStyleFilterType(GraphicalStyleFilter.Include).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cvector");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles_filter_type=include");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithMinimumSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithMinimumSize(MinimumSize.Xlarge).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_size=x_large");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithNumberOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithNumberOfPeople(NumberOfPeople.One | NumberOfPeople.Group).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("number_of_people=one%2Cgroup");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithOrientation()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithOrientation(Orientation.Horizontal | Orientation.Square).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Csquare");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithPage(2).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .SearchImages()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithPrestigeContent()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithPrestigeContentOnly().ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("prestige_content_only=True");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithSortOrder(SortOrder.Newest).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=newest");
        }

        [Fact]
        public async Task SearchForBlendedImagesWithSpecificPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var people = new List<string>() { "Reggie Jackson" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImages()
                .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
        }
    }
}
