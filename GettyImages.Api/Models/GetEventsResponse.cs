// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetEventsResponse
{
    public Event[] Events { get; set; }
    public int[] EventsNotFound { get; set; }
}