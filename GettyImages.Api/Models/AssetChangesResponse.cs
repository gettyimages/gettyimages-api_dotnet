// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace GettyImages.Api.Models;

public class AssetChangesResponse
{
    public string ChangeSetId { get; set; }
    public ChangedAssetDetail[] ChangedAssets { get; set; }
}