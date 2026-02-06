using System;

namespace GettyImages.Api.Models;

public class AssetUsage
{
    public string AssetId { get; set; }
    public int Quantity { get; set; }
    public DateTime UsageDate { get; set; }
}
