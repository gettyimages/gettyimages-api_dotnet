// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace GettyImages.Api.Models;


public class AddBoardAssetsResponse
{
    public BoardAsset[] AssetsAdded { get; set; }
    public string[] AssetsNotAdded { get; set; }
}
