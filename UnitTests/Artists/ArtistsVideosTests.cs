using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Artists;

public class ArtistsVideosTests
{
    [Fact]
    public async Task SearchForVideosByArtistBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsVideos()
            .WithArtist("roman makhmutov").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
    }

    [Fact]
    public async Task SearchForVideosByArtistWithFields()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var fields = new List<string> { "asset_family", "keywords" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsVideos()
            .WithArtist("roman makhmutov").WithResponseFields(fields).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Ckeywords");
    }

    [Fact]
    public async Task SearchForVideosByArtistWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsVideos()
            .WithArtist("roman makhmutov").WithPage(3).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task SearchForVideosByArtistWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsVideos()
            .WithArtist("roman makhmutov").WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/videos");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }
}