using System.Net.Http.Json;
using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;
using GettyImages.Api.Models;

using Xunit;

namespace UnitTests.AiGenerator;

public class ReDownloadTests : IAsyncLifetime
{
    private redownload_request _requestPayload;
    private string _absoluteUri;

    public async Task InitializeAsync()
    {
        var testHandler = TestUtil.CreateTestHandler();
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .GeneratedImageRedownload()
            .With(new GeneratedImageRedownloadRequest
            {
                GeneratedAssetId = "A6503762-4A4B-4434-8445-2C1335A95A78",
                ProductId = 1234,
                SizeName = ImageGenerationsSize.FourK,
                ProjectCode = "some project code",
                Notes = "some notes"
            })
            .ExecuteAsync();

        _requestPayload = await testHandler.Request.Content!.ReadFromJsonAsync<redownload_request>();
        _absoluteUri = testHandler.Request.RequestUri!.AbsoluteUri;
    }

    [Fact]
    public void ProductIdIsAttached()
    {
        _requestPayload.product_id.Should().Be(1234);
    }

    [Fact]
    public void GeneratedAssetIdIsAttached()
    {
        _requestPayload.generated_asset_id.Should().Be("A6503762-4A4B-4434-8445-2C1335A95A78");
    }

    [Fact]
    public void NotesAreAttached()
    {
        _requestPayload.notes.Should().Be("some notes");
    }

    [Fact]
    public void ProjectCodeIsAttached()
    {
        _requestPayload.project_code.Should().Be("some project code");
    }

    [Fact]
    public void SizeNameIsAttached()
    {
        _requestPayload.size_name.Should().Be("4k");
    }

    [Fact]
    public void UriIsExpected()
    {
        _absoluteUri.Should().Be("https://api.gettyimages.com/v3/ai/redownloads");
    }

    public class redownload_request
    {
        public string generated_asset_id { get; set; }
        public int product_id { get; set; }
        public string size_name { get; set; }
        public string project_code { get; set; }
        public string notes { get; set; }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}
