using System.Threading.Tasks;
using AwesomeAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AiGenerator;

public class GetGeneratedImagesTests : IAsyncLifetime
{
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetGeneratedImages()
            .WithGenerationRequestId("5D4F2A7A-95DA-44AC-800B-AF57B5E9E3C4")
            .ExecuteAsync();

        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;

    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should().Be("https://api.gettyimages.com/v3/ai/image-generations/5D4F2A7A-95DA-44AC-800B-AF57B5E9E3C4");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}