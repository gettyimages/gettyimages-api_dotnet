// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchEditorialVideosResponse
{
    public int ResultCount { get; set; }
    public EditorialVideoSearchItem[] Videos { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}