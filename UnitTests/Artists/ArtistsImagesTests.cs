using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Artists;

public class ArtistsImagesTests
{
    [Fact]
    public async Task SearchForImagesByArtistBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
            .WithArtist("roman makhmutov").ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
    }

    [Fact]
    public async Task SearchForImagesByArtistWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
            .WithArtist("roman makhmutov").WithPage(3).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task SearchForImagesByArtistWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
            .WithArtist("roman makhmutov").WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }
}