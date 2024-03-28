using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace IntegrationTests;

public class GenerateImagesTests : IClassFixture<GenerateImagesTests.Fixture>
{
    private readonly Fixture _fixture;

    public GenerateImagesTests(Fixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GenerationRequestIdReturned()
    {
        _fixture.Response.GenerationRequestId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ResultsArePresent()
    {
        _fixture.Response.Results.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void MultipleResultsArePresent()
    {
        _fixture.Response.Results.Length.Should().BePositive();
    }

    public class Fixture : BaseFixture, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            Response = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GenerateImages()
                .WithDownloadDetails(new ImageGenerationsRequest
                {
                    Prompt = "a prompt",
                    Mood = ImageGenerationsMood.Dramatic,
                    Notes = "some notes",
                    AspectRatio = "9:16",
                    MediaType = ImageGenerationsMediaType.Photography,
                    NegativePrompt = "something to subtract from the prompt",
                    ProductId = ProductId,
                })
                .ExecuteAsync();
        }

        public ImageGenerationsReadyResponse Response { get; set; }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}