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
    public void ImageGenerationsResponse_GenerationRequestIdReturned()
    {
        _fixture.ImageGenerationsResponse.GenerationRequestId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ImageGenerationsResponse_ResultsArePresent()
    {
        _fixture.ImageGenerationsResponse.Results.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void ImageGenerationsResponse_MultipleResultsArePresent()
    {
        _fixture.ImageGenerationsResponse.Results.Length.Should().BePositive();
    }

    
    [Fact]
    public void GetGeneratedImagesResponse_GenerationRequestIdReturned()
    {
        _fixture.GetGeneratedImagesResponse.GenerationRequestId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImagesResponse_ResultsArePresent()
    {
        _fixture.GetGeneratedImagesResponse.Results.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImagesResponse_MultipleResultsArePresent()
    {
        _fixture.GetGeneratedImagesResponse.Results.Length.Should().BePositive();
    }

    public class Fixture : BaseFixture, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            ImageGenerationsResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .ImageGenerations()
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

            if (ImageGenerationsResponse != null && ImageGenerationsResponse.GenerationRequestId != null)
            {
                GetGeneratedImagesResponse = await ApiClient
                    .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                    .GetGeneratedImages()
                    .WithGenerationRequestId(ImageGenerationsResponse.GenerationRequestId)
                    .ExecuteAsync();
            }
        }

        // TODO - Naming is confusing
        public ImageGenerationsReadyResponse GetGeneratedImagesResponse { get; private set; }

        // TODO - Naming is confusing
        public ImageGenerationsReadyResponse ImageGenerationsResponse { get; private set; }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}