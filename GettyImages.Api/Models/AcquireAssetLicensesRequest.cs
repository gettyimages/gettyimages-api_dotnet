namespace GettyImages.Api.Models;

public class AcquireAssetLicensesRequest
{
    public ExtendedLicense[] ExtendedLicenses { get; set; }
    public bool UseTeamCredits { get; set; }
}