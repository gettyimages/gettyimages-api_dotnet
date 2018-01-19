using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetChanges
{
    public class DeleteAssetChangesTests
    {
        [Fact]
        public void DeleteAssetChangesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var response = ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .DeleteAssetChanges().WithChangeSetId(155432).ExecuteAsync().Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("asset-changes/change-sets/155432");
        }
    }
}
