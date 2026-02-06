namespace GettyImages.Api.Models;

public class ImageGenerationsReadyResponse
{
    public string GenerationRequestId { get; set; }

    public Result[] Results { get; set; }

    public class Result
    {
        public int Index { get; set; }
        public string Url { get; set; }
    }
}
