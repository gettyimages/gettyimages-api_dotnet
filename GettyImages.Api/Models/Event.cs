// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class Event
{
    public int ChildEventCount { get; set; }
    public string[] EditorialSegments { get; set; }
    public HeroImage HeroImage { get; set; }
    public int Id { get; set; }
    public int ImageCount { get; set; }
    public LocationEvent Location { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
}