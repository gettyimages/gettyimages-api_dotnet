// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class DownloadRequirements
{
    public bool IsNoteRequired { get; set; }
    public bool IsProjectCodeRequired { get; set; }
    public string[] ProjectCodes { get; set; }
}