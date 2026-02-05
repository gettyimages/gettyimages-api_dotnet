using System.Net.Http.Json;
using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.AiGenerator;

public class DownloadGeneratedImageTests : IAsyncLifetime
{
    private download_generated_image_request _requestPayload;
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DownloadGeneratedImage()
            .With(generationRequestId: "A6503762-4A4B-4434-8445-2C1335A95A78" , index: 2, 
                new GeneratedImageDownloadRequest
                {
                    SizeName = ImageGenerationsSize.FourK,
                    Notes = "some notes",
                    ProjectCode = "a project code"
                })
            .ExecuteAsync();

        _requestPayload = await testHandler.Request.Content!.ReadFromJsonAsync<download_generated_image_request>();
        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;

    }

    [Fact]
    public void SizeNameIsAttached()
    {
        _requestPayload.size_name.Should().Be("4k");
    }

    [Fact]
    public void ProjectCodeIsAttached()
    {
        _requestPayload.project_code.Should().Be("a project code");
    }

    [Fact]
    public void NotesAreAttached()
    {
        _requestPayload.notes.Should().Be("some notes");
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should()
            .Be("https://api.gettyimages.com/v3/ai/image-generations/A6503762-4A4B-4434-8445-2C1335A95A78/images/2/download");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    
    public class download_generated_image_request
    {
        public string notes { get; set; }
        public string project_code { get; set; }
        public string size_name { get; set; }
    }
}