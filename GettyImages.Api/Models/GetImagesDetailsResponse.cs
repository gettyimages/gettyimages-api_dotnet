// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetImagesDetailsResponse
{
    public ImageDetail[] Images { get; set; }
    public string[] ImagesNotFound { get; set; }
}
