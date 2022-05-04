// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchCreativeImagesByImageResponse
{
    public int ResultCount { get; set; }
    public CreativeSearchFacets Facets { get; set; }
    public ImageSearchItemCreative[] Images { get; set; }
}
