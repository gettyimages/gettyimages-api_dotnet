// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class DownloadSize
{
    public long Bytes { get; set; }
    public Download[] Downloads { get; set; }
    public double Height { get; set; }
    public string MediaType { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Dpi { get; set; }
}