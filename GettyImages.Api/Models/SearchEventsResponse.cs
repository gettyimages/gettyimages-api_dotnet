// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class SearchEventsResponse
{
    public Event[] Events { get; set; }
    public int ResultCount { get; set; }
}
