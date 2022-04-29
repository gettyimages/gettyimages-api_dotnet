// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class AssetDownloadHistoryItem
{
    public DateTime DateDownloaded { get; set; }
    public string AssetType { get; set; }
    public AssetDownloadHistoryUser User { get; set; }
    public string ProductType { get; set; }
    public string AgreementName { get; set; }
    public int ProductId { get; set; }
    public string DownloadNotes { get; set; }
    public string ProjectCode { get; set; }
    public string DownloadSource { get; set; }
}