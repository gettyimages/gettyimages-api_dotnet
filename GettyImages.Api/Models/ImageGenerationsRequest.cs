namespace GettyImages.Api.Models;

public class ImageGenerationsRequest
{
    public string Prompt { get; set; }
    public string NegativePrompt { get; set; }
    public string AspectRatio { get; set; }
    public ImageGenerationsMediaType? MediaType { get; set; }
    public ImageGenerationsMood? Mood { get; set; }
    public int ProductId { get; set; }
    public string ProjectCode { get; set; }
    public string Notes { get; set; }
}
