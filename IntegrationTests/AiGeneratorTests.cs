using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace IntegrationTests;

/// <summary>
/// The AI Generator operations are more complex than the other operations in the API.
/// Locally-run integration tests are warranted to ensure that the operations are functioning as expected.
/// </summary>
public class AiGeneratorTests : IClassFixture<AiGeneratorTests.Fixture>
{
    private readonly Fixture _fixture;

    public AiGeneratorTests(Fixture fixture)
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

    [Fact]
    public void DownloadGeneratedImageResponse_GeneratedAssetId()
    {
        _fixture.DownloadGeneratedImageResponse.GeneratedAssetId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void DownloadGeneratedImageResponse_Url()
    {
        _fixture.DownloadGeneratedImageResponse.Url.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImageDownloadResponse_GeneratedAssetId()
    {
        _fixture.GetGeneratedImageDownloadResponse.GeneratedAssetId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImageDownloadResponse_Url()
    {
        _fixture.GetGeneratedImageDownloadResponse.Url.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void RedownloadGeneratedImageResponse_GeneratedAssetId()
    {
        _fixture.RedownloadGeneratedImageResponse.GeneratedAssetId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void RedownloadGeneratedImageResponse_Url()
    {
        _fixture.RedownloadGeneratedImageResponse.Url.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetDownloadSizesResponse_DownloadSizes()
    {
        _fixture.GetDownloadSizesResponse.DownloadSizes.Length.Should().BePositive();
    }

    [Fact]
    public void GetDownloadSizesResponse_SizeName()
    {
        _fixture.GetDownloadSizesResponse.DownloadSizes[0].SizeName.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetDownloadSizesResponse_Height()
    {
        _fixture.GetDownloadSizesResponse.DownloadSizes[0].Height.Should().BePositive();
    }

    [Fact]
    public void GetDownloadSizesResponse_Width()
    {
        _fixture.GetDownloadSizesResponse.DownloadSizes[0].Width.Should().BePositive();
    }

    [Fact]
    public void GetGeneratedImageVariationsResponse_GenerationRequestId()
    {
        _fixture.GetGeneratedImageVariationsResponse.GenerationRequestId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImageVariationsResponse_Results()
    {
        _fixture.GetGeneratedImageVariationsResponse.Results.Length.Should().BePositive();
    }

    [Fact]
    public void GetGeneratedImageVariationsResponse_Results_Url()
    {
        _fixture.GetGeneratedImageVariationsResponse.Results[1].Url.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void GetGeneratedImageVariationsResponse_Results_Index()
    {
        _fixture.GetGeneratedImageVariationsResponse.Results[1].Index.Should().BePositive();
    }

    public class Fixture : BaseFixture, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            ImageGenerationsResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .ImageGenerations()
                .WithImageGenerationsRequest(new ImageGenerationsRequest
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

            GetGeneratedImagesResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GetGeneratedImages()
                .WithGenerationRequestId(ImageGenerationsResponse.GenerationRequestId)
                .ExecuteAsync();

            DownloadGeneratedImageResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .DownloadGeneratedImage()
                .With(ImageGenerationsResponse.GenerationRequestId, 2, new GeneratedImageDownloadRequest{SizeName = ImageGenerationsSize.FourK})
                .ExecuteAsync();

            RedownloadGeneratedImageResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GeneratedImageRedownload()
                .With(new GeneratedImageRedownloadRequest
                {
                    GeneratedAssetId = DownloadGeneratedImageResponse.GeneratedAssetId,
                    ProductId = ProductId,
                    SizeName = ImageGenerationsSize.FourK,
                    Notes = "API SDK Integration Test"
                })
                .ExecuteAsync();

            GetGeneratedImageDownloadResponse = await ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GetGeneratedImageDownload()
                .With(ImageGenerationsResponse.GenerationRequestId, 2)
                .ExecuteAsync();
            
            GetDownloadSizesResponse = await  ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GetDownloadSizes()
                .With(generationRequestId: ImageGenerationsResponse.GenerationRequestId, index: 3)
                .ExecuteAsync();
            
            GetGeneratedImageVariationsResponse = await  ApiClient
                .GetApiClientWithResourceOwnerCredentials(ApiKey, ApiSecret, UserName, UserPassword)
                .GetGeneratedImageVariations()
                .With(generationRequestId: ImageGenerationsResponse.GenerationRequestId, index: 3, new GenerationVariationsRequest
                {
                    Notes = "API SDK Integration Test",
                    ProductId = ProductId
                })
                .ExecuteAsync();
        }

        public DownloadGeneratedImageReadyResponse RedownloadGeneratedImageResponse { get; set; }

        public ImageGenerationsReadyResponse GetGeneratedImageVariationsResponse { get; private set; }

        public GeneratedDownloadSizesResponse GetDownloadSizesResponse { get; private set; }

        public DownloadGeneratedImageReadyResponse GetGeneratedImageDownloadResponse { get; private set; }

        public DownloadGeneratedImageReadyResponse DownloadGeneratedImageResponse { get; private set; }

        public ImageGenerationsReadyResponse GetGeneratedImagesResponse { get; private set; }

        public ImageGenerationsReadyResponse ImageGenerationsResponse { get; private set; }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}