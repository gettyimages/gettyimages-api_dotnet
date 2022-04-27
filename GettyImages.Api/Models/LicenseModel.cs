using System;

namespace GettyImages.Api.Models;

[Flags]
public enum LicenseModel
{
    None = 0,
    RightsManaged = 1,
    RoyaltyFree = 2,
    RightsReady = 4
}