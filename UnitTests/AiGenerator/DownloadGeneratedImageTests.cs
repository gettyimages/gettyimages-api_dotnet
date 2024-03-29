using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AiGenerator;

public class DownloadGeneratedImageTests : IAsyncLifetime
{
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .DownloadGeneratedImage()
            .With(generationRequestId: "A6503762-4A4B-4434-8445-2C1335A95A78" , index: 2)
            .ExecuteAsync();

        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;

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
}