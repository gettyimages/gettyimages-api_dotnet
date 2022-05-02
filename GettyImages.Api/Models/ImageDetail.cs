// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;

namespace GettyImages.Api.Models;

public class ImageDetail
{
    public string Id { get; set; }
    public AllowedUse AllowedUse { get; set; }
    public Dictionary<string, string> AlternativeIds { get; set; }
    public string Artist { get; set; }
    public string ArtistTitle { get; set; }
    public string AssetFamily { get; set; }
    public bool CallForImage { get; set; }
    public string Caption { get; set; }
    public string City { get; set; }
    public string CollectionCode { get; set; }
    public int CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string ColorType { get; set; }
    public string Copyright { get; set; }
    public string Country { get; set; }
    public string CreditLine { get; set; }
    public DateTime? DateCameraShot { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateSubmitted { get; set; }
    public DisplaySize[] DisplaySizes { get; set; }
    public string DownloadProduct { get; set; }
    public DownloadSize[] DownloadSizes { get; set; }
    public string[] EditorialSegments { get; set; }
    public EditorialSource EditorialSource { get; set; }
    public long[] EventIds { get; set; }
    public string GraphicalStyle { get; set; }
    public string IstockCollection { get; set; }
    public string IstockLicenses { get; set; }
    public Keyword[] Keywords { get; set; }
    public DownloadSize[] LargestDownloads { get; set; }
    public string LicenseModel { get; set; }
    public ImageDetailLink[] Links { get; set; }
    public Dimensions MaxDimensions { get; set; }
    public string ObjectName { get; set; }
    public Orientation Orientation { get; set; }
    public string[] People { get; set; }
    public ProductType[] ProductTypes { get; set; }
    public int QualityRank { get; set; }
    public ReferralDestination[] ReferralDestinations { get; set; }
    public string StateProvince { get; set; }
    public string Title { get; set; }
    public string UriOembed { get; set; }
}