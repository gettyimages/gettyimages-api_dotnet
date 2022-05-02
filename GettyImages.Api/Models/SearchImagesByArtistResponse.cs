// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchImagesByArtistResponse
{
    public int ResultCount { get; set; }
    public ArtistAssetSearchItem[] Images { get; set; }
}