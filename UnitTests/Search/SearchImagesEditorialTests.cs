using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Search
{
    public class SearchImagesEditorialTests
    {
        [Fact]
        public void SearchForEditorialImagesWithPhrase()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }

        [Fact]
        public void SearchForEditorialImagesWithAgeOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
        }

        [Fact]
        public void SearchForEditorialImagesWithArtist()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var artists = new List<string>() { "roman makhmutov", "Linda Raymond" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithArtists(artists).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
        }

        [Fact]
        public void SearchForEditorialImagesWithCollectionCodes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var codes = new List<string>() { "WRI", "ARF" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
        }

        [Fact]
        public void SearchForEditorialImagesWithCollectionFilterType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
        }

        [Fact]
        public void SearchForEditorialImagesWithComposition()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
        }

        [Fact]
        public void SearchForEditorialImagesWithDownloadProduct()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
               .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
        }

        [Fact]
        public void SearchForEditorialImagesWithEditorialSegment()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEditorialSegment(EditorialSegment.Archival | EditorialSegment.Publicity).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_segments=archival%2Cpublicity");
        }

        [Fact]
        public void SearchForEditorialImagesWithEmbedContentOnly()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEmbedContentOnly().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("embed_content_only=True");
        }

        [Fact]
        public void SearchForEditorialImagesWithEndDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEndDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
        }

        [Fact]
        public void SearchForEditorialImagesWithEntityUris()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var uris = new List<string>() { "example_uri_1", "example_uri_2" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEntityUris(uris).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("entity_uris=example_uri_1%2Cexample_uri_2");
        }

        [Fact]
        public void SearchForEditorialImagesWithEthnicity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEthnicity(Ethnicity.Black | Ethnicity.Japanese).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ethnicity=black%2Cjapanese");
        }

        [Fact]
        public void SearchForEditorialImagesWithEventIds()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 518451, 518452 };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithEventIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452");
        }

        [Fact]
        public void SearchForEditorialImagesWithExcludeNudity()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithExcludeNudity().ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
        }

        [Fact]
        public void SearchForEditorialImagesWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "asset_family", "id" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
        }

        [Fact]
        public void SearchForEditorialImagesWithFileTypes()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithFileType(FileType.Eps | FileType.Jpg).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_types=eps%2Cjpg");
        }

        [Fact]
        public void SearchForEditorialImagesWithGraphicalStyle()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt).WithGraphicalStyle(GraphicalStyles.Illustration).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cillustration");
        }

        [Fact]
        public void SearchForBlendedImagesWithGraphicalStyleFilter()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Vector).WithGraphicalStyleFilterType(GraphicalStyleFilter.Include).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cvector");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles_filter_type=include");
        }

        [Fact]
        public void SearchForEditorialImagesWithKeywordId()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<int>() { 64284, 67255 };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
        }

        [Fact]
        public void SearchForEditorialImagesWithMinimumQualtiy()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithMinimumQuality(MinimumQuality.One).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_quality_rank=1");
        }

        [Fact]
        public void SearchForEditorialImagesWithMinimumSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithMinimumSize(MinimumSize.Small).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_size=small");
        }

        [Fact]
        public void SearchForEditorialImagesWithNumberOfPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithNumberOfPeople(NumberOfPeople.One | NumberOfPeople.Group).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("number_of_people=one%2Cgroup");
        }

        [Fact]
        public void SearchForEditorialImagesWithOrientation()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithOrientation(Orientation.Horizontal | Orientation.Square).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Csquare");
        }

        [Fact]
        public void SearchForEditorialImagesWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithPage(2).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
        }

        [Fact]
        public void SearchForEditorialImagesWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }

        [Fact]
        public void SearchForEditorialImagesWithProductType()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithProductType(ProductType.Easyaccess).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=easyaccess");
        }


        [Fact]
        public void SearchForEditorialImagesWithSortOrder()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithSortOrder(SortOrder.BestMatch).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
        }

        [Fact]
        public void SearchForEditorialImagesWithSpecificPeople()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var people = new List<string>() { "Reggie Jackson" };

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
        }

        [Fact]
        public void SearchForEditorialImagesWithStartDate()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
                .WithPhrase("cat").WithStartDate("2015-04-01").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        }
    }
}
