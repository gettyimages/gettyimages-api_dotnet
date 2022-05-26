using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Search;

public class SearchImagesEditorialTests
{
    [Fact]
    public async Task SearchForEditorialImagesWithPhrase()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithAgeOfPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithArtist()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var artists = new List<string> { "roman makhmutov", "Linda Raymond" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithArtists(artists).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithCollectionCodes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var codes = new List<string> { "WRI", "ARF" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithCollectionFilterType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithComposition()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithDownloadProduct()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEditorialSegment()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEditorialSegment(EditorialSegment.Archival | EditorialSegment.Publicity)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_segments=archival%2Cpublicity");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEmbedContentOnly()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEmbedContentOnly().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("embed_content_only=True");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEndDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEndDate("2015-04-01").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEntityUris()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var uris = new List<string> { "example_uri_1", "example_uri_2" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEntityUris(uris).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("entity_uris=example_uri_1%2Cexample_uri_2");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEthnicity()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEthnicity(Ethnicity.Black | Ethnicity.Japanese).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ethnicity=black%2Cjapanese");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithEventIds()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 518451, 518452 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithEventIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("event_ids=518451%2C518452");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithExcludeKeywordIds()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithExcludeKeywordIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_keyword_ids=64284%2C67255");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithExcludeNudity()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithResponseFields()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithFileTypes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithFileType(FileType.Eps | FileType.Jpg).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_types=eps%2Cjpg");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithGraphicalStyle()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt)
            .WithGraphicalStyle(GraphicalStyles.Illustration).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cillustration");
    }

    [Fact]
    public async Task SearchForBlendedImagesWithGraphicalStyleFilter()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Vector)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cvector");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles_filter_type=include");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithRelatedSearches()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").IncludeRelatedSearches().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_related_searches=True");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithKeywordId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithMinimumQualtiy()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithMinimumQuality(MinimumQuality.One).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_quality_rank=1");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithMinimumSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithMinimumSize(MinimumSize.Small).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_size=small");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithNumberOfPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithNumberOfPeople(NumberOfPeople.One | NumberOfPeople.Group).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("number_of_people=one%2Cgroup");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithOrientation()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithOrientation(OrientationImages.Horizontal | OrientationImages.Square).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Csquare");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithPage(2).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithSortOrder()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithSortOrder(SortOrderEditorial.BestMatch).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithSpecificPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var people = new List<string> { "Reggie Jackson" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
    }

    [Fact]
    public async Task SearchForEditorialImagesWithStartDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesEditorial()
            .WithPhrase("cat").WithStartDate("2015-04-01").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
    }
}