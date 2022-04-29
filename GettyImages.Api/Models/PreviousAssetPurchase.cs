// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class PreviousAssetPurchase
{
    public DateTime DatePurchased { get; set; }
    public string PurchasedBy { get; set; }
    public string AssetId { get; set; }
    public string AssetType { get; set; }
    public string LicenseModel { get; set; }
    public string OrderId { get; set; }
    public string ThumbUri { get; set; }
    public string SizeName { get; set; }
    public string FileSizeInBytes { get; set; }
    public string DownloadUri { get; set; }
}