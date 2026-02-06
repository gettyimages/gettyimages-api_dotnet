// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class AssetLicensingResponse
{
    public int CreditsUsed { get; set; }
    public ExtendedLicense[] AcquiredLicenses { get; set; }
}
