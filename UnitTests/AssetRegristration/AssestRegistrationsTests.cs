using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetRegristration
{
    public class AssestRegistrationsTests
    {
        [Fact]
        public async Task AssetRegistrationsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var request = @"{
            'asset_ids': [
            'string'
                ]
            }";

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .AssetRegistrations().WithRequest(request).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-registrations");
        }
    }
}
