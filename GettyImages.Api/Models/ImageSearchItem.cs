// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;

namespace GettyImages.Api.Models;

public class ImageSearchItem
{
    public AllowedUse AllowedUse { get; set; }
    public Dictionary<string, string> AlternativeIds { get; set; }
    public string Artist { get; set; }
    public string AssetFamily { get; set; }
    public bool CallForImage { get; set; }
    public string Caption { get; set; }
    public string CollectionCode { get; set; }
    public int? CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string ColorType { get; set; }
    public string Copyright { get; set; }
    public DateTime? DateCameraShot { get; set; }
    public DateTime? DateCreated { get; set; }
    public AssetSearchItemDisplaySize[] DisplaySizes { get; set; }
    public string DownloadProduct { get; set; }
    public string[] EditorialSegments { get; set; }
    public int[] EventIds { get; set; }
    public string GraphicalStyle { get; set; }
    public string Id { get; set; }
    public Keyword[] Keywords { get; set; }
    public Download[] LargestDownloads { get; set; }
    public string LicenseModel { get; set; }
    public MaxDimensions MaxDimensions { get; set; }
    public string Orientation { get; set; }
    public string[] People { get; set; }
    public string[] ProductTypes { get; set; }
    public int QualityRank { get; set; }
    public ReferralDestination[] ReferralDestinations { get; set; }
    public string Title { get; set; }
    public string UriOembed { get; set; }
    public IStockLicense[] IstockLicenses { get; set; }
}
