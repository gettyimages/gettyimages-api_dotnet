// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchCreativeVideosResponse
{
    public int ResultCount { get; set; }
    public CreativeVideoSearchItem[] Videos { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public AutoCorrections AutoCorrections { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}
