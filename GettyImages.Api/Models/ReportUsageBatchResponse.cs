// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class ReportUsageBatchResponse
{
    public string[] InvalidAssets { get; set; }
    public int TotalAssetUsagesProcessed { get; set; }
}
