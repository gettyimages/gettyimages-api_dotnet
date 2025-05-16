// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class HistoricalDownload
{
    public DateTime DateDownloaded { get; set; }
    public string Id { get; set; }
    public string AssetType { get; set; }
    public string ProductType { get; set; }
    public string ThumbUri { get; set; }
    public string AgreementName { get; set; }
    public int ProductId { get; set; }
    public DownloadDetails DownloadDetails { get; set; }
    public string DownloadSource { get; set; }
    public User User { get; set; }
    public string SizeName { get; set; }
    public Dimensions Dimensions { get; set; }
    public string LicenseModel { get; set; }
}