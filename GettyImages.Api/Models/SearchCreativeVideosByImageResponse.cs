// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
using System;

namespace GettyImages.Api.Models;

public class SearchCreativeVideosByImageResponse
{
    public int ResultCount { get; set; }
    public CreativeSearchFacets Facets { get; set; }
    public CreativeVideoSearchByImageItem[] Videos { get; set; }
}

public class CreativeVideoSearchByImageItem
{
    public string Id { get; set; }
    public AllowedUse AllowedUse { get; set; }
    public string Artist { get; set; }
    public string AspectRatio { get; set; }
    public string AssetFamily { get; set; }
    public bool CallForImage { get; set; }
    public string Caption { get; set; }
    public string ClipLength { get; set; }
    public int CollectionId { get; set; }
    public string CollectionCode { get; set; }
    public string CollectionName { get; set; }
    public string ColorType { get; set; }
    public string Copyright { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateSubmitted { get; set; }
    public VideoSearchItemDisplaySize[] DisplaySizes { get; set; }
    public string DownloadProduct { get; set; }
    public VideoDownloadSize[] DownloadSizes { get; set; }
    public string Era { get; set; }
    public string IstockCollection { get; set; }
    public CreativeKeyword[] Keywords { get; set; }
    public Download[] LargestDownloads { get; set; }
    public string LicenseModel { get; set; }
    public string MasteredTo { get; set; }
    public string Orientation { get; set; }
    public string OriginallyShotOn { get; set; }
    public string[] ProductTypes { get; set; }
    public int QualityRank { get; set; }
    public ReferralDestination[] ReferralDestinations { get; set; }
    public string ShotSpeed { get; set; }
    public string Title { get; set; }
}