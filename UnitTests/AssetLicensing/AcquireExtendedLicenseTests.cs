using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.AssetLicensing
{
    public class AcquireExtendedLicenseTests
    {
        [Fact]
        public async Task AcquireExtendedLicenseBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();
            var requestBody = @"{
                                 'LicenseTypes':['Indemnification','Multiseat'],
                                 'UseTeamCredits':false
                                }";

            var assetId = "123";
            await ApiClient.GetApiClientWithResourceOwnerCredentials("apiKey", "apiSecret", "userName", "userPassword",  testHandler)
                .AcquireExtendedLicense()
                .WithAssetId(assetId)
                .WithExtendedLicenses(requestBody)
                .ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain(string.Format("/asset-licensing/{0}", assetId));
            var content = await testHandler.Request.Content.ReadAsStringAsync();
            content.Should().Contain(requestBody);
        }
    }
}
