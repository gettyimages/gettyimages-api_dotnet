using System.Linq;
using System.Threading.Tasks;

using AwesomeAssertions;

using GettyImages.Api;
using GettyImages.Api.Models;

using Xunit;

namespace UnitTests.AssetLicensing;

public class AcquireExtendedLicenseTests
{
    [Fact]
    public async Task AcquireExtendedLicenseBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();
        var requestBody = new AcquireAssetLicensesRequest
        {
            ExtendedLicenses = new[] { ExtendedLicense.Multiseat },
            UseTeamCredits = true
        };

        var assetId = "123";
        await ApiClient
            .GetApiClientWithResourceOwnerCredentials("apiKey", "apiSecret", "userName", "userPassword", testHandler)
            .AcquireExtendedLicense()
            .WithAssetId(assetId)
            .WithExtendedLicenses(requestBody)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain($"/asset-licensing/{assetId}");
        var requestString = await testHandler.Request.Content.ReadAsStringAsync();
        var content = Serializer.Deserialize<AcquireAssetLicensesRequest>(requestString);
        content.ExtendedLicenses.First().Should().Be(ExtendedLicense.Multiseat);
        content.UseTeamCredits.Should().BeTrue();
    }
}
