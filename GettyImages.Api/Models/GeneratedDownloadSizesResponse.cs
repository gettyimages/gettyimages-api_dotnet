namespace GettyImages.Api.Models;

public class GeneratedDownloadSizesResponse
{
    public DownloadSize[] DownloadSizes { get; set; }

    public class DownloadSize
    {
        public string SizeName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}