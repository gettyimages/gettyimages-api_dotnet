using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.AiGenerator;

public class GetVariationsTests : IAsyncLifetime
{
    // Get variations on a generated image
    private image_variations_request? _requestPayload;
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GeneratedImageVariations()
            .With(generationRequestId: "A6503762-4A4B-4434-8445-2C1335A95A78", index: 2,
                new GenerationVariationsRequest
                {
                    Notes = "some notes",
                    ProductId = 1234,
                    ProjectCode = "some project code"
                })
            .ExecuteAsync();

        _requestPayload = await testHandler.Request.Content!
            .ReadFromJsonAsync<image_variations_request>();
        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;
    }

    [Fact]
    public void NotesAreAttached()
    {
        _requestPayload.notes.Should().Be("some notes");
    }

    [Fact]
    public void ProductIdIsAttached()
    {
        _requestPayload.product_id.Should().Be(1234);
    }

    [Fact]
    public void ProjectCodeIsAttached()
    {
        _requestPayload.project_code.Should().Be("some project code");
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should().Be("https://api.gettyimages.com/v3/ai/image-generations/A6503762-4A4B-4434-8445-2C1335A95A78/images/2/variations");
    }

    public class image_variations_request
    {
        public string notes { get; set; }
        public string project_code { get; set; }
        public int? product_id { get; set; }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}