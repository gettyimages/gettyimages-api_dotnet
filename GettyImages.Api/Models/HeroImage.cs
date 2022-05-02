// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class HeroImage
{
    public string Id { get; set; }
    public HeroImageDisplaySize[] DisplaySizes { get; set; }
}