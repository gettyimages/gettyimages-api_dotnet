using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.AiGenerator;

public class GenerateImagesTests : IAsyncLifetime
{
    private image_generations_request _requestPayload;
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GenerateImages()
            .WithImageGenerationsRequest(new ImageGenerationsRequest
            {
                Prompt = "a prompt",
                Mood = ImageGenerationsMood.Dramatic,
                Notes = "some notes",
                AspectRatio = "9:16",
                MediaType = ImageGenerationsMediaType.Photography,
                NegativePrompt = "something to subtract from the prompt",
                ProductId = 1234,
                ProjectCode = "some project code"
            })
            .ExecuteAsync();

        _requestPayload = await testHandler.Request.Content!.ReadFromJsonAsync<image_generations_request>();
        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;

    }

    [Fact]
    public void PromptIsAttached()
    {
        _requestPayload.prompt.Should().Be("a prompt");
    }

    [Fact]
    public void ProductIdIsAttached()
    {
        _requestPayload.product_id.Should().Be(1234);
    }

    [Fact]
    public void MediaTypeIsAttached()
    {
        _requestPayload.media_type.Should().Be("photography");
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should().Be("https://api.gettyimages.com/v3/ai/image-generations");
    }

    public class image_generations_request
    {
        public string prompt { get; set; }
        public string media_type { get; set; }
        public int? product_id { get; set; }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}