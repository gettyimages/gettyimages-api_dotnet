// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchFacetsResponse
{
    public SpecificPeople[] SpecificPeople { get; set; }
    public FacetEvent[] Events { get; set; }
    public Location[] Locations { get; set; }
    public Artist[] Artists { get; set; }
    public Entertainment[] Entertainment { get; set; }
}
