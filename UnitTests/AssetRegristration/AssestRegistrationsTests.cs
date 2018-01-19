using System.Collections.Generic;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetRegristration
{
    public class AssestRegistrationsTests
    {
        [Fact]
        public void AssetRegistrationsBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var request = @"{
            'asset_ids': [
            'string'
                ]
            }";

            List<string> ids = new List<string>();
            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .AssetRegistrations().WithRequest(request).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-registrations");
        }
    }
}
