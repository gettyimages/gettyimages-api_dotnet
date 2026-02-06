// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class OverageDetails
{
    public int Limit { get; set; }
    public int Remaining { get; set; }
    public int Count { get; set; }
    public bool OveragesReached { get; set; }
}
