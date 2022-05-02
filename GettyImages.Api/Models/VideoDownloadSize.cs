// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class VideoDownloadSize
{
    public string BitDepth { get; set; }
    public string Compression { get; set; }
    public string ContentType { get; set; }
    public string Description { get; set; }
    public Download[] Downloads { get; set; }
    public string Format { get; set; }
    public double FrameRate { get; set; }
    public string FrameSize { get; set; }
    public decimal Height { get; set; }
    public bool Interlaced { get; set; }
    public long Bytes { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
}