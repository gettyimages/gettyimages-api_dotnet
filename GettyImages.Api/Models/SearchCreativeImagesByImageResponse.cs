// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchCreativeImagesByImageResponse
{
    public RelatedSearch[] RelatedSearches { get; set; }
    public int ResultCount { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public AutoCorrections AutoCorrections { get; set; }
    public ImageSearchItemCreative[] Images { get; set; }
}