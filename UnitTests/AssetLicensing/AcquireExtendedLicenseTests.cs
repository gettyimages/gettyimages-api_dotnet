using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetLicensing
{
    public class AcquireExtendedLicenseTests
    {
        [Fact]
        public void AcquireExtendedLicenseBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();
            var requestBody = @"{
                                 'LicenseTypes':['Indemnification','Multiseat'],
                                 'UseTeamCredits':false
                                }";

            var assetId = "123";
            var response = ApiClient.GetApiClientWithResourceOwnerCredentials("apiKey", "apiSecret", "userName", "userPassword",  testHandler)
                .AcquireExtendedLicense()
                .WithAssetId(assetId)
                .WithExtendedLicenses(requestBody)
                .ExecuteAsync()
                .Result;

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain(string.Format("/asset-licensing/{0}", assetId));
            testHandler.Request.Content.ReadAsStringAsync().Result.Should().Contain(requestBody);
        }
    }
}
