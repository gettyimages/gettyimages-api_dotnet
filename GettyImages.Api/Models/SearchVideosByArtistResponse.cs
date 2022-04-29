// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchVideosByArtistResponse
{
    public int ResultCount { get; set; }
    public ArtistAssetSearchItem[] Videos { get; set; }
}