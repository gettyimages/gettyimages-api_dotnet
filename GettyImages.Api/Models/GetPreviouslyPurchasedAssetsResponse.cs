// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetPreviouslyPurchasedAssetsResponse
{
    public int ResultCount { get; set; }
    public PreviousAssetPurchase[] PreviousPurchases { get; set; }
}
