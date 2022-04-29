// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetDownloadsResponse
{
    public int ResultCount { get; set; }
    public HistoricalDownload[] Downloads { get; set; }
}