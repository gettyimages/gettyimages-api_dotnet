// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchCreativeImagesResponse
{
    public int ResultCount { get; set; }
    public ImageSearchItemCreative[] Images { get; set; }
    public AutoCorrections AutoCorrections { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}