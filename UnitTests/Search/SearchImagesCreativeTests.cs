using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Search;

public class SearchImagesCreativeTests
{
    [Fact]
    public async Task SearchForCreativeImagesWithPhrase()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithAgeOfPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithArtist()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var artists = new List<string> { "roman makhmutov", "Linda Raymond" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithArtists(artists).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithCollectionCodes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var codes = new List<string> { "WRI", "ARF" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithCollectionFilterType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithColor()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithColor("#002244").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("color=%23002244");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithComposition()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithDownloadProduct()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithEmbedContentOnly()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithEmbedContentOnly().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("embed_content_only=True");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithEthnicity()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithEthnicity(Ethnicity.Black | Ethnicity.Japanese).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ethnicity=black%2Cjapanese");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithExcludeKeywordIds()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithExcludeKeywordIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_keyword_ids=64284%2C67255");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithExcludeNudity()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithExcludeNudity().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_nudity=True");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithWithExcludeEditorialUseOnly()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithExcludeEditorialUseOnly().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_editorial_use_only=True");
    }

    // TODO: add new test
    // [Fact]
    // public async Task SearchForCreativeImagesWithResponseFields()
    // {
    //     var testHandler = TestUtil.CreateTestHandler();
    //
    //     var fields = new List<CreativeImagesFieldValues> {  CreativeImagesFieldValues.AssetFamily, CreativeImagesFieldValues.Id };
    //
    //     await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
    //         .WithPhrase("cat").WithResponseFields(fields).ExecuteAsync();
    //
    //     testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
    //     testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    //     testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Cid");
    // }

    [Fact]
    public async Task SearchForCreativeImagesWithFileTypes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithFileType(FileType.Eps | FileType.Jpg).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("file_types=eps%2Cjpg");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithGraphicalStyle()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Illustration)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cillustration");
    }

    [Fact]
    public async Task SearchForBlendedImagesWithGraphicalStyleFilter()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithGraphicalStyle(GraphicalStyles.FineArt | GraphicalStyles.Vector)
            .WithGraphicalStyleFilterType(GraphicalStyleFilter.Include).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles=fine_art%2Cvector");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("graphical_styles_filter_type=include");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithKeywordId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithMinimumSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithMinimumSize(MinimumSize.Small).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("minimum_size=small");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithNumberOfPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithNumberOfPeople(NumberOfPeople.One | NumberOfPeople.Group).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("number_of_people=one%2Cgroup");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithOrientation()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithOrientation(Orientation.Horizontal | Orientation.Square).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Csquare");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithPage(2).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchImagesCreative()
            .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithPrestigeContent()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithPrestigeContentOnly().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("prestige_content_only=True");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithProductType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithProductType(ProductType.Easyaccess | ProductType.Editorialsubscription)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_types=editorialsubscription%2Ceasyaccess");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithSortOrder()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchImagesCreative()
            .WithPhrase("cat").WithSortOrder(SortOrderCreative.BestMatch).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
    }

    [Fact]
    public async Task SearchForCreativeImagesWithFacets()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchImagesCreative()
            .WithIncludeFacets()
            .WithFacetMaxCount(200)
            .WithFacetFields(new List<string> { "artists", "locations" })
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_facets=True");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("facet_fields=artists%2Clocations");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("maxcount=200");
    }
}