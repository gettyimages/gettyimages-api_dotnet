using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Search;

public class SearchVideosEditorialTests
{
    [Fact]
    public async Task SearchForEditorialVideosWithPhrase()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithAgeOfPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithAgeOfPeople(AgeOfPeople.Months6To11 | AgeOfPeople.Adult).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("age_of_people=adult%2C6-11_months");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithArtist()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var artists = new List<string> { "roman makhmutov", "Linda Raymond" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithArtists(artists).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithAspectRatios()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithAspectRatios(AspectRatio.AspectRatio4_3 | AspectRatio.AspectRatio16_9).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("aspect_ratios=16%3A9%2C4%3A3");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithCollectionCodes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var codes = new List<string> { "WRI", "ARF" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithCollectionCodes(codes).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collection_codes=WRI%2CARF");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithCollectionFilterType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithCollectionFilterType(CollectionFilter.Exclude).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("collections_filter_type=exclude");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithComposition()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithDownloadProduct()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithDownloadProduct(ProductType.Easyaccess).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=easyaccess");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithDownloadProductAndProductId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithDownloadProduct(ProductType.Premiumaccess, 1234).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("download_product=premiumaccess%3A1234");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithEditorialVideoType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithEditorialVideoType(EditorialVideo.Raw | EditorialVideo.Produced).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("editorial_video_types=raw%2Cproduced");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithEntityUri()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var uris = new List<string> { "example_uri_1", "example_uri_2" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithEntityUris(uris).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("entity_uris=example_uri_1%2Cexample_uri_2");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithResponseFields()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithFormatFilter()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithAvailableFormat(FormatAvailable.HD).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("format_available=hd");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithFrameRates()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithFrameRate(FrameRate.FrameRate24 | FrameRate.FrameRate29).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("frame_rates=24%2C29.97");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithRelatedSearches()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").IncludeRelatedSearches().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_related_searches=True");
    }


    [Fact]
    public async Task SearchForEditorialVideosWithImageTechniques()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithImageTechniques(ImageTechnique.SelectiveFocus | ImageTechnique.TimeLapse).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("image_techniques=time_lapse%2Cselective_focus");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithKeywordId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithKeywordIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("keyword_ids=64284%2C67255");
    }


    [Fact]
    public async Task SearchForEditorialVideosWithOrientation()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithOrientation(OrientationVideos.Horizontal | OrientationVideos.Vertical).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Cvertical");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithPage(2).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }


    [Fact]
    public async Task SearchForEditorialVideosWithSortOrder()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithSortOrder(SortOrderEditorial.BestMatch).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("sort_order=best_match");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithSpecificPeople()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var people = new List<string> { "Reggie Jackson" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithSpecificPeople(people).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("specific_people=Reggie+Jackson");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithReleaseStatus()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithReleaseStatus(ReleaseStatus.FullyReleased).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("release_status=fully_released");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithMinimumClipLength()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithMinimumVideoClipLength(20).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithMaximumClipLength()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithMaximumVideoClipLength(200).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithMinimumAndMaximumClipLength()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithMinimumVideoClipLength(20).WithMaximumVideoClipLength(200).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("min_clip_length=20");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("max_clip_length=200");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithViewpoints()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosEditorial()
            .WithPhrase("cat").WithViewpoints(Viewpoint.HighAngleView | Viewpoint.Panning).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("viewpoints=panning%2Chigh_angle_view");
    }

    [Fact]
    public async Task SearchForEditorialVideosWithFacets()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchVideosEditorial()
            .IncludeFacets()
            .WithFacetMaxCount(200)
            .WithFacetFields(FacetFieldsEditorial.Artists | FacetFieldsEditorial.Locations)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/editorial");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_facets=True");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("facet_fields=artists%2Clocations");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("maxcount=200");
    }
}