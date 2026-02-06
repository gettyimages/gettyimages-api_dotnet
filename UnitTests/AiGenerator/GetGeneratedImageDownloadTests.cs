using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.AiGenerator;

public class GetGeneratedImageDownloadTests : IAsyncLifetime
{
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetGeneratedImageDownload()
            .With(generationRequestId: "CD9C0632-732C-4F8D-9F96-420B07985B50", index: 2)
            .ExecuteAsync();

        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should()
            .Be("https://api.gettyimages.com/v3/ai/image-generations/CD9C0632-732C-4F8D-9F96-420B07985B50/images/2/download");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
