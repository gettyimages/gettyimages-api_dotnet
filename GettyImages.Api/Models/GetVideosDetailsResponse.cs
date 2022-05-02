// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetVideosDetailsResponse
{
    public Video[] Videos { get; set; }
    public string[] VideosNotFound { get; set; }
}