// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class Video
{
    public string Id { get; set; }
    public AllowedUse AllowedUse { get; set; }
    public string Artist { get; set; }
    public string AssetFamily { get; set; }
    public bool CallForImage { get; set; }
    public string Caption { get; set; }
    public string ClipLength { get; set; }
    public string CollectionCode { get; set; }
    public int CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string ColorType { get; set; }
    public string Copyright { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateSubmitted { get; set; }
    public DisplaySize[] DisplaySizes { get; set; }
    public string DownloadProduct { get; set; }
    public VideoDownloadSize[] DownloadSizes { get; set; }
    public string[] EditorialSegments { get; set; }
    public string Era { get; set; }
    public int[] EventIds { get; set; }
    public string IstockCollection { get; set; }
    public IStockLicense[] IstockLicenses { get; set; }
    public Keyword[] Keywords { get; set; }
    public string LicenseModel { get; set; }
    public string MasteredTo { get; set; }
    public string ObjectName { get; set; }
    public string OriginallyShotOn { get; set; }
    public string[] ProductTypes { get; set; }
    public int QualityRank { get; set; }
    public ReferralDestination[] ReferralDestinations { get; set; }
    public string ShotSpeed { get; set; }
    public string Source { get; set; }
    public string Title { get; set; }
}