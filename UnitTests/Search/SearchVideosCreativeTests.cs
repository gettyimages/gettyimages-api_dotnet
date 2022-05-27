using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Search;

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
    public async Task SearchForCreativeVideosWithArtist()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var artists = new List<string> { "roman makhmutov", "Linda Raymond" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithArtists(artists).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists=roman+makhmutov%2CLinda+Raymond");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithAspectRatios()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithAspectRatios(AspectRatio.AspectRatio4_3 | AspectRatio.AspectRatio16_9).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("aspect_ratios=16%3A9%2C4%3A3");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithCollectionCodes()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var codes = new List<string> { "WRI", "ARF" };

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
    public async Task SearchForCreativeVideosWithComposition()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithComposition(Composition.Headshot | Composition.Abstract).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("compositions=abstract%2Cheadshot");
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
    public async Task SearchForCreativeVideosWithWithExcludeEditorialUseOnly()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithExcludeEditorialUseOnly().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("exclude_editorial_use_only=True");
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
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithFormatFilter()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithAvailableFormat(FormatAvailable.HD).ExecuteAsync();

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
    public async Task SearchForCreativeVideosWithRelatedSearches()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").IncludeRelatedSearches().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_related_searches=True");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithImageTechniques()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithImageTechniques(ImageTechnique.SelectiveFocus | ImageTechnique.TimeLapse).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("image_techniques=time_lapse%2Cselective_focus");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithKeywordId()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<int> { 64284, 67255 };

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
    public async Task SearchForCreativeVideosWithOrientation()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithOrientation(OrientationVideos.Horizontal | OrientationVideos.Vertical).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("orientations=horizontal%2Cvertical");
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
    public async Task SearchForCreativeVideosWithSafeSearch()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithSafeSearch()
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("safe_search=True");
    }


    [Fact]
    public async Task SearchForCreativeVideosWithSortOrder()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithSortOrder(SortOrderCreative.BestMatch).ExecuteAsync();

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

    [Fact]
    public async Task SearchForCreativeVideosWithViewpoints()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).SearchVideosCreative()
            .WithPhrase("cat").WithViewpoints(Viewpoint.HighAngleView | Viewpoint.Panning).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("viewpoints=panning%2Chigh_angle_view");
    }

    [Fact]
    public async Task SearchForCreativeVideosWithFacets()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .SearchVideosCreative()
            .IncludeFacets()
            .WithFacetMaxCount(200)
            .WithFacetFields(FacetFieldsCreative.Artists | FacetFieldsCreative.Locations)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/videos/creative");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("include_facets=True");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("facet_fields=artists%2Clocations");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("maxcount=200");
    }
}