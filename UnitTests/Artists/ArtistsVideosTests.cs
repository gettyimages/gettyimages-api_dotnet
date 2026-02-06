using System.Threading.Tasks;

using AwesomeAssertions;

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
