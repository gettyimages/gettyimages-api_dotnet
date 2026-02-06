using System.Collections.Generic;
using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Images;

public class ImagesTests
{
    [Fact]
    public async Task MultipleImagesBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var ids = new List<string> { "882449540", "629219532" };

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Images().WithIds(ids).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
    }

    [Fact]
    public async Task SingleImageBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Images().WithIds(new[] { "882449540" }).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540");
    }
}
