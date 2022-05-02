// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchEditorialImagesResponse
{
    public int ResultCount { get; set; }
    public ImageSearchItemEditorial[] Images { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}