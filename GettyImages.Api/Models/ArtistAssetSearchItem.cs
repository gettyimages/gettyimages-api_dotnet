// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;

namespace GettyImages.Api.Models;

public class ArtistAssetSearchItem
{
    public ArtistAssetSearchAllowedUse AllowedUse { get; set; }
    public Dictionary<string, string> AlternativeIds { get; set; }
    public string Artist { get; set; }
    public string AssetFamily { get; set; }
    public string AssetType { get; set; }
    public bool CallForImage { get; set; }
    public string Caption { get; set; }
    public string ClipLength { get; set; }
    public string CollectionCode { get; set; }
    public int? CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string Copyright { get; set; }
    public DateTime DateSubmitted { get; set; }
    public DateTime DateCreated { get; set; }
    public AssetSearchItemDisplaySize[] DisplaySizes { get; set; }
    public string[] EditorialSegments { get; set; }
    public int[] EventIds { get; set; }
    public string GraphicalStyle { get; set; }
    public string Id { get; set; }
    public ArtistAssetSearchKeyword[] Keywords { get; set; }
    public string LicenseModel { get; set; }
    public MaxDimensions MaxDimensions { get; set; }
    public string Orientation { get; set; }
    public string[] ProductTypes { get; set; }
    public int QualityRank { get; set; }
    public ReferralDestination[] ReferralDestinations { get; set; }
    public string Title { get; set; }
}