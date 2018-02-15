using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Artists
{
    public class ArtistsImagesTests
    {
        [Fact]
        public void SearchForImagesByArtistBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages().WithArtist("roman makhmutov").ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
        }

        [Fact]
        public void SearchForImagesByArtistWithFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() {"asset_family", "keywords"};

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
                .WithArtist("roman makhmutov").WithResponseFields(fields).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=asset_family%2Ckeywords");
        }

        [Fact]
        public void SearchForImagesByArtistWithPage()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
                .WithArtist("roman makhmutov").WithPage(3).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
        }

        [Fact]
        public void SearchForImagesByArtistWithPageSize()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).ArtistsImages()
                .WithArtist("roman makhmutov").WithPageSize(50).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artists/images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("artist_name=roman+makhmutov");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
        }
    }
}
