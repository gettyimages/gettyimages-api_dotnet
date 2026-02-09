using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.AiGenerator;

public class GetDownloadSizesTests : IAsyncLifetime
{
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GetDownloadSizes()
            .With(generationRequestId: "9BDF6A13-4C06-41C4-BF59-14D761C7233E", index: 3)
            .ExecuteAsync();

        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should()
            .Be(
                "https://api.gettyimages.com/v3/ai/image-generations/9BDF6A13-4C06-41C4-BF59-14D761C7233E/images/3/download-sizes");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
