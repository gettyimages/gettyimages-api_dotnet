using FluentAssertions;
using GettyImages.Api;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Credentials
{
    public class CredentialsTests
    {
        [Fact]
        public async Task GetApiClientWithOnlyApiKey()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithApiKey("apiKey", testHandler).SearchImagesCreative()
                .WithPhrase("cat").ExecuteAsync();
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }
    }
}
