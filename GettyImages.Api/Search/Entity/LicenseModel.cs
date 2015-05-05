using System;

namespace GettyImages.Api.Search.Entity
{
    [Flags]
    public enum LicenseModel
    {
        None = 0,
        RightsManaged = 1,
        RoyaltyFree = 2,
        RightsReady = 4
    }
}