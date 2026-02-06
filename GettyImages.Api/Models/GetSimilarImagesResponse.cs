// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetSimilarImagesResponse
{
    public int ResultCount { get; set; }
    public ImageSearchItem[] Images { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}
