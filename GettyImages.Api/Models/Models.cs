﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GettyImages.Api.Entity;

// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class AffiliateSearchStyle
{
}

public class AffiliateImageUrls
{
    public string Small { get; set; }

    public int SmallHeight { get; set; }

    public int SmallWidth { get; set; }

    public string Medium { get; set; }

    public int MediumHeight { get; set; }

    public int MediumWidth { get; set; }

    public string Large { get; set; }

    public int LargeHeight { get; set; }

    public int LargeWidth { get; set; }
}

public class AffiliateImage
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public AffiliateImageUrls PreviewUrls { get; set; }

    public string DestinationUrl { get; set; }
}

public class AutoCorrections
{
    public string Phrase { get; set; }
}

public class AffiliateImageSearchResponse
{
    public AffiliateImage[] Images { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
}

public class AffiliateVideoUrls
{
    public string SmallStill { get; set; }

    public string MediumStill { get; set; }

    public string LargeStill { get; set; }

    public string SmallMotion { get; set; }

    public string LargeMotion { get; set; }
}

public class AffiliateVideo
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public AffiliateVideoUrls PreviewUrls { get; set; }

    public string DestinationUrl { get; set; }

    public string ClipLength { get; set; }
}

public class AffiliateVideoSearchResponse
{
    public AffiliateVideo[] Videos { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
}

public class ArtistsImageSearchFieldValues
{
}

public class ArtistsVideoSearchFieldValues
{
}

public enum ExtendedLicense
{
    Multiseat,
    Unlimited,
    Resale,
    Indemnification
}

public class AcquireAssetLicensesRequest
{
    public ExtendedLicense[] ExtendedLicenses { get; set; }

    public bool UseTeamCredits { get; set; }
}

public class AssetLicensingResponse
{
    public int CreditsUsed { get; set; }

    public ExtendedLicense[] AcquiredLicenses { get; set; }
}

public class AssetEvent
{
    public DateTime Timestamp { get; set; }

    public string AssetId { get; set; }

    public string EmailAddress { get; set; }
}

public class GetSendEventsResponse
{
    public DateTime LastOffset { get; set; }

    public AssetEvent[] AssetSendEvents { get; set; }
}

public class Collection
{
    public string AssetFamily { get; set; }

    public string Code { get; set; }

    public int Id { get; set; }

    public string LicenseModel { get; set; }

    public string Name { get; set; }

    public string[] ProductTypes { get; set; }
}

public class GetCollectionsResponse
{
    public Collection[] Collections { get; set; }
}

public class Country
{
    [JsonPropertyName("iso_alpha_2")] public string IsoAlpha2 { get; set; }

    [JsonPropertyName("iso_alpha_3")] public string IsoAlpha3 { get; set; }

    public string Name { get; set; }
}

public class CountriesList
{
    public Country[] Countries { get; set; }
}

public class CuratedSet
{
    public string SetId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateLastUpdated { get; set; }

    public string HeroImageUri { get; set; }

    public string[] Assets { get; set; }

    public string[] Keywords { get; set; }
}

public class CustomerInfoResponse
{
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }
}

public class LogLevel
{
}

public class MemcachedLogEntry
{
    public DateTime Time { get; set; }

    public string LogLevel { get; set; }

    public string Message { get; set; }

    public string ExceptionMessage { get; set; }
}

public class DownloadAssetResponse
{
    public string Uri { get; set; }
}

public class DownloadFileType
{
}

public class ProductTypeRequest
{
}

public class PremiumAccessDownloadData
{
    public string DownloadNotes { get; set; }

    public string ProjectCode { get; set; }
}

public class DownloadDetails
{
    public string DownloadNotes { get; set; }

    public string ProjectCode { get; set; }
}

public class User
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }
}

public class Dimensions
{
    public int Width { get; set; }

    public int Height { get; set; }

    public int Dpi { get; set; }
}

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
}

public class GetDownloadsResponse
{
    public int ResultCount { get; set; }

    public HistoricalDownload[] Downloads { get; set; }
}

public class EventDetailFieldValues
{
}

public class ImageDetailFieldValues
{
}

public class ImagesDetailResponse
{
    public ImageDetail[] Images { get; set; }
    public string[] ImagesNotFound { get; set; }
}

public class ImageDetail
{
    public string Id { get; set; }
    public AssetDetailAllowedUse AllowedUse { get; set; }
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

public class ImageDetailLink
{
    public string Rel { get; set; }
    public string Uri { get; set; }
}

public class DownloadSize
{
    public long Bytes { get; set; }
    public Download[] Downloads { get; set; }
    public double Height { get; set; }
    public string MediaType { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Dpi { get; set; }
}

public class ImagesFieldValues
{
}

public class AllowedUse
{
    [JsonPropertyName("HowCanIUseIt")] public string HowCanIUseIt { get; set; }

    [JsonPropertyName("ReleaseInfo")] public string ReleaseInfo { get; set; }

    [JsonPropertyName("UsageRestrictions")]
    public string[] UsageRestrictions { get; set; }

    [JsonPropertyName("Code")] public string Code { get; set; }
}

public class AssetDetailAllowedUse
{
    public string HowCanIUseIt { get; set; }

    public string ReleaseInfo { get; set; }

    public string[] UsageRestrictions { get; set; }
}

public class AssetSearchAllowedUse
{
    public string HowCanIUseIt { get; set; }

    public string ReleaseInfo { get; set; }

    public string[] UsageRestrictions { get; set; }
}

public class Contributor
{
    public string MemberName { get; set; }

    public string DisplayName { get; set; }
}

public class AssetSearchItemDisplaySize
{
    public bool IsWatermarked { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }
}

public class Keyword
{
    public string KeywordId { get; set; }

    public string Text { get; set; }

    public string Type { get; set; }

    public int? Relevance { get; set; }

    public string[] EntityUris { get; set; }

    public string[] EntityTypes { get; set; }
}

public class Download
{
    public string ProductId { get; set; }

    public string ProductType { get; set; }

    public string Uri { get; set; }

    public string AgreementName { get; set; }
}

public class MaxDimensions
{
    public int Height { get; set; }

    public int Width { get; set; }
}

public class ReferralDestination
{
    public string SiteName { get; set; }

    public string Uri { get; set; }
}

public class TerritoryRestriction
{
    public string CountryCode { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }
}

public class IStockLicense
{
    public string LicenseType { get; set; }

    public int Credits { get; set; }
}

public class ImageSearchItem
{
    public AssetDetailAllowedUse AllowedUse { get; set; }

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

public class RelatedSearch
{
    public string Phrase { get; set; }

    public string Url { get; set; }
}

public class ImageSearchItemSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItem[] Images { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class AssetDownloadHistoryResults
{
    public AssetDownloadHistoryItem[] Downloads { get; set; }
}

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

public class AssetDownloadHistoryUser
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}

public class OrderNotes
{
    public string LicenseeName { get; set; }

    public string PurchaseOrderNumber { get; set; }

    public string ProjectTitle { get; set; }

    public string OrderedBy { get; set; }
}

public class AssetIdFromOrder
{
    public string Id { get; set; }
}

public class OrderDetail
{
    public string Id { get; set; }

    public string InvoiceNumber { get; set; }

    public DateTime OrderDate { get; set; }

    public string EndClient { get; set; }

    public OrderNotes Notes { get; set; }

    public AssetIdFromOrder[] Assets { get; set; }
}

public class ProductStatusRequest
{
}

public class ProductFieldValues
{
}

public class ProductStatus
{
}

public class ProductTypeResponse
{
}

public class DownloadRequirements
{
    public bool IsNoteRequired { get; set; }

    public bool IsProjectCodeRequired { get; set; }

    public string[] ProjectCodes { get; set; }
}

public class OverageDetails
{
    public int Limit { get; set; }

    public int Remaining { get; set; }

    public int Count { get; set; }

    public bool OveragesReached { get; set; }
}

public class Product
{
    public string ApplicationWebsite { get; set; }

    public int? CreditsRemaining { get; set; }

    public int? DownloadLimit { get; set; }

    public string DownloadLimitDuration { get; set; }

    public DateTime? DownloadLimitResetUtcDate { get; set; }

    public int? DownloadsRemaining { get; set; }

    public DateTime? ExpirationUtcDate { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Status { get; set; }

    public string Type { get; set; }

    public DownloadRequirements DownloadRequirements { get; set; }

    public OverageDetails Overage { get; set; }

    public string AgreementName { get; set; }

    public string ImagepackResolution { get; set; }

    public int? TeamCredits { get; set; }
}

public class GetProductsResponse
{
    public Product[] Products { get; set; }
}

public class PreviousPurchase
{
    public DateTime DatePurchased { get; set; }

    public string ImageId { get; set; }

    public string LicenseModel { get; set; }

    public string OrderId { get; set; }

    public string ThumbUri { get; set; }
}

public class PreviousPurchaseResponse
{
    public int ResultCount { get; set; }

    public PreviousPurchase[] PreviousPurchases { get; set; }
}

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

public class GetPreviouslyPurchasedAssetsResponse
{
    public int ResultCount { get; set; }

    public PreviousAssetPurchase[] PreviousPurchases { get; set; }
}

public class AgeOfPeopleFilterType
{
}

public class CollectionsFilterType
{
}

public class CompositionsFilterType
{
}

public class EthnicityFilterType
{
}

public class SearchFileType
{
}

public class GraphicalStyle
{
}

public class GraphicalStylesFilterType
{
}

public class LicenseModelImageRequest
{
}

public class TeeShirtSize
{
}

public class NumberOfPeopleFilterType
{
}

public class OrientationRequest
{
}

public class BlendedImageSortOrder
{
}

public class CreativeImagesFieldValues
{
}

public class CreativeImageSortOrder
{
}

public class CreateImageSearchFacetsFields
{
}

public class ImageSearchItemCreative
{
    public AssetSearchAllowedUse AllowedUse { get; set; }

    public Dictionary<string, string> AlternativeIds { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public bool CallForImage { get; set; }

    public string Caption { get; set; }

    public string CollectionCode { get; set; }

    public int CollectionId { get; set; }

    public string CollectionName { get; set; }

    public string ColorType { get; set; }

    public string Copyright { get; set; }

    public DateTime? DateCameraShot { get; set; }

    public DateTime? DateCreated { get; set; }

    public AssetSearchItemDisplaySize[] DisplaySizes { get; set; }

    public string DownloadProduct { get; set; }

    public string GraphicalStyle { get; set; }

    public string Id { get; set; }

    public Keyword[] Keywords { get; set; }

    public Download[] LargestDownloads { get; set; }

    public string LicenseModel { get; set; }

    public MaxDimensions MaxDimensions { get; set; }

    public string Orientation { get; set; }

    public int QualityRank { get; set; }

    public ReferralDestination[] ReferralDestinations { get; set; }

    public string Title { get; set; }

    public string UriOembed { get; set; }
}

public class CreativeImageSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItemCreative[] Images { get; set; }

    public AutoCorrections AutoCorrections { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class SpecificPeople
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class FacetEvent
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Date { get; set; }
}

public class Location
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class Artist
{
    public string Name { get; set; }
}

public class Entertainment
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public class SearchFacetsResponse
{
    public SpecificPeople[] SpecificPeople { get; set; }

    public FacetEvent[] Events { get; set; }

    public Location[] Locations { get; set; }

    public Artist[] Artists { get; set; }

    public Entertainment[] Entertainment { get; set; }
}

public class SearchByImageResourceResults
{

    public RelatedSearch[] RelatedSearches { get; set; }

    public int ResultCount { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
    
    public ImageSearchItemCreative[] Images { get; set; }
}

public class EditorialSegmentContract
{
}

public class EditorialImagesFieldValues
{
}

public class EditorialGraphicalStyle
{
}

public class SortOrder
{
}

public class EditorialImageSearchFacetsFields
{
}

public class EditorialSource
{
    public int Id { get; set; }
}

public class ImageSearchItemEditorial
{
    public AssetSearchAllowedUse AllowedUse { get; set; }

    public Dictionary<string, string> AlternativeIds { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public bool CallForImage { get; set; }

    public string Caption { get; set; }

    public string CollectionCode { get; set; }

    public int CollectionId { get; set; }

    public string CollectionName { get; set; }

    public string ColorType { get; set; }

    public string Copyright { get; set; }

    public DateTime? DateCameraShot { get; set; }

    public DateTime? DateCreated { get; set; }

    public AssetSearchItemDisplaySize[] DisplaySizes { get; set; }

    public string DownloadProduct { get; set; }

    public string[] EditorialSegments { get; set; }

    public EditorialSource EditorialSource { get; set; }

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
}

public class EditorialImageSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItemEditorial[] Images { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class VideoAspectRatioFilterType
{
}

public class EditorialVideoType
{
}

public class VideoFormatsRequest
{
}

public class VideoFrameRates
{
}

public class BlendedVideosFieldValues
{
}

public class LicenseModelVideoRequest
{
}

public class VideoOrientationRequest
{
}

public class ReleaseStatus
{
}

public class VideoSearchItemDisplaySize
{
    public bool IsWatermarked { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }

    public string AspectRatio { get; set; }
}

public class BlendedVideoSearchItem
{
    public string Source { get; set; }

    public string Id { get; set; }

    public AllowedUse AllowedUse { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public string Caption { get; set; }

    public string ClipLength { get; set; }

    public int CollectionId { get; set; }

    public string CollectionCode { get; set; }

    public string CollectionName { get; set; }

    public string ColorType { get; set; }

    public string Copyright { get; set; }

    public DateTime DateCreated { get; set; }

    public VideoSearchItemDisplaySize[] DisplaySizes { get; set; }

    public string DownloadProduct { get; set; }

    public string Era { get; set; }

    public int[] EventIds { get; set; }

    public Keyword[] Keywords { get; set; }

    public Download[] LargestDownloads { get; set; }

    public string LicenseModel { get; set; }

    public string MasteredTo { get; set; }

    public string OriginallyShotOn { get; set; }

    public string[] ProductTypes { get; set; }

    public ReferralDestination[] ReferralDestinations { get; set; }

    public string ShotSpeed { get; set; }

    public string Title { get; set; }

    public IStockLicense[] IstockLicenses { get; set; }
}

public class BlendedVideoSearchResults
{
    public int ResultCount { get; set; }

    public BlendedVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class CreativeVideosFieldValues
{
}

public class ImageTechniquesFilterType
{
}

public class CreativeVideoSortOrder
{
}

public class CreateVideoSearchFacetsFields
{
}

public class ViewpointsFilterType
{
}

public class CreativeVideoSearchItem
{
    public string Id { get; set; }

    public AssetSearchAllowedUse AllowedUse { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public string Caption { get; set; }

    public string ClipLength { get; set; }

    public int CollectionId { get; set; }

    public string CollectionCode { get; set; }

    public string CollectionName { get; set; }

    public string ColorType { get; set; }

    public string Copyright { get; set; }

    public DateTime DateCreated { get; set; }

    public VideoSearchItemDisplaySize[] DisplaySizes { get; set; }

    public string DownloadProduct { get; set; }

    public string Era { get; set; }

    public int[] EventIds { get; set; }

    public Keyword[] Keywords { get; set; }

    public Download[] LargestDownloads { get; set; }

    public string LicenseModel { get; set; }

    public string MasteredTo { get; set; }

    public string OriginallyShotOn { get; set; }

    public string[] ProductTypes { get; set; }

    public ReferralDestination[] ReferralDestinations { get; set; }

    public string ShotSpeed { get; set; }

    public string Title { get; set; }

    public IStockLicense[] IstockLicenses { get; set; }
}

public class CreativeVideoSearchResults
{
    public int ResultCount { get; set; }

    public CreativeVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public AutoCorrections AutoCorrections { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class EditorialVideosFieldValues
{
}

public class EditorialVideoSearchFacetsFields
{
}

public class EditorialVideoSearchItem
{
    public string Source { get; set; }

    public string Id { get; set; }

    public AssetSearchAllowedUse AllowedUse { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public string Caption { get; set; }

    public string ClipLength { get; set; }

    public int CollectionId { get; set; }

    public string CollectionCode { get; set; }

    public string CollectionName { get; set; }

    public string ColorType { get; set; }

    public string Copyright { get; set; }

    public DateTime DateCreated { get; set; }

    public VideoSearchItemDisplaySize[] DisplaySizes { get; set; }

    public string DownloadProduct { get; set; }

    public string Era { get; set; }

    public int[] EventIds { get; set; }

    public Keyword[] Keywords { get; set; }

    public Download[] LargestDownloads { get; set; }

    public string LicenseModel { get; set; }

    public string MasteredTo { get; set; }

    public string OriginallyShotOn { get; set; }

    public string[] ProductTypes { get; set; }

    public ReferralDestination[] ReferralDestinations { get; set; }

    public string ShotSpeed { get; set; }

    public string Title { get; set; }

    public IStockLicense[] IstockLicenses { get; set; }
}

public class EditorialVideoSearchResults
{
    public int ResultCount { get; set; }

    public EditorialVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public class EventFieldValues
{
}

public class EventSearchSortOrder
{
}

public class HeroImageDisplaySize
{
    public string Name { get; set; }

    public bool IsWatermarked { get; set; }

    public string Uri { get; set; }
}

public class HeroImage
{
    public string Id { get; set; }

    public HeroImageDisplaySize[] DisplaySizes { get; set; }
}

public class LocationEvent
{
    public string City { get; set; }

    public string Country { get; set; }

    public string StateProvince { get; set; }

    public string Venue { get; set; }
}

public class Event
{
    public int ChildEventCount { get; set; }

    public string[] EditorialSegments { get; set; }

    public HeroImage HeroImage { get; set; }

    public int Id { get; set; }

    public int ImageCount { get; set; }

    public LocationEvent Location { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }
}

public class EventsSearchResult
{
    public Event[] Events { get; set; }

    public int ResultCount { get; set; }
}

public class GetEventsResponse
{
    public Event[] Events { get; set; }
    public int[] EventsNotFound { get; set; }
}

public class VideoDetailFieldValues
{
}

public class AssetUsage
{
    public string AssetId { get; set; }

    public int Quantity { get; set; }

    public DateTime UsageDate { get; set; }
}

public class ReportUsageBatchRequest
{
    public AssetUsage[] AssetUsages { get; set; }
}

public class ReportUsageBatchResponse
{
    public string[] InvalidAssets { get; set; }

    public int TotalAssetUsagesProcessed { get; set; }
}

public class ChangedAssetDetail
{
    public DateTime AssetChangedUtcDatetime { get; set; }

    public string AssetLifecycle { get; set; }

    public string AssetType { get; set; }

    public string Id { get; set; }

    public string Uri { get; set; }
}

public class AssetChanges
{
    public string ChangeSetId { get; set; }

    public ChangedAssetDetail[] ChangedAssets { get; set; }
}

public class AssetFamily
{
}

public class AssetType
{
}

public class Channel
{
    public int ChannelId { get; set; }

    public string AssetFamily { get; set; }

    public string ChannelType { get; set; }

    public DateTime StartDate { get; set; }

    public int NotificationCount { get; set; }

    public string AssetType { get; set; }

    public DateTime OldestNotificationDateUtc { get; set; }
}

public class BoardRelationship
{
}

public class BoardSortOrder
{
}

public class DisplaySize
{
    public string Name { get; set; }

    public string Uri { get; set; }
}

public class Asset
{
    public string Id { get; set; }

    public string AssetType { get; set; }

    public DateTime DateAdded { get; set; }

    public DisplaySize[] DisplaySizes { get; set; }
}

public class GetBoardsResponse
{
    public BoardBasic[] Boards { get; set; }

    public int BoardCount { get; set; }
}

public class BoardInfo
{
    public string Name { get; set; }

    public string Description { get; set; }
}

public class CreateBoardResponse
{
    public string Id { get; set; }
}

public class BoardPermissions
{
    public bool CanDeleteBoard { get; set; }

    public bool CanInviteToBoard { get; set; }

    public bool CanUpdateName { get; set; }

    public bool CanUpdateDescription { get; set; }

    public bool CanAddAssets { get; set; }

    public bool CanRemoveAssets { get; set; }
}

public class Links
{
    public string Invitation { get; set; }

    public string Share { get; set; }
}

public class BoardBasic
{
    public string Id { get; set; }

    public int AssetCount { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateLastUpdated { get; set; }

    public string Description { get; set; }

    public Asset HeroAsset { get; set; }

    public string Name { get; set; }

    public string BoardRelationship { get; set; }
}

public class BoardDetail
{
    public string Id { get; set; }

    public int AssetCount { get; set; }

    public Asset[] Assets { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateLastUpdated { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public int CommentCount { get; set; }

    public BoardPermissions Permissions { get; set; }

    public Links Links { get; set; }
}

public class BoardAsset
{
    public string AssetId { get; set; }
}

public class AddBoardAssetsResult
{
    public BoardAsset[] AssetsAdded { get; set; }

    public string[] AssetsNotAdded { get; set; }
}

public class Collaborator
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

public class CommentPermissions
{
    public bool CanDeleteComment { get; set; }
}

public class Comment
{
    public Collaborator CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public string Id { get; set; }

    public CommentPermissions Permissions { get; set; }

    public string Text { get; set; }
}

public class BoardCommentPermissions
{
    public bool CanAddComment { get; set; }
}

public class GetCommentsResponse
{
    public Comment[] Comments { get; set; }

    public BoardCommentPermissions Permissions { get; set; }
}

public class CommentRequest
{
    public string Text { get; set; }
}

public class CreateCommentResponse
{
    public string Id { get; set; }
}

public class SelfResult
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}

public class CreateReportRequest
{
    public string ReportTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

public class ProblemDetails
{
    public string Type { get; set; }

    public string Title { get; set; }

    public int Status { get; set; }

    public string Detail { get; set; }

    public string Instance { get; set; }
}

public class ReportMetadataResponse
{
    public string Id { get; set; }

    public string ReportStatus { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

public class ReportsMetadataResponse
{
    public ReportMetadataResponse[] Reports { get; set; }
}

public class ReportStatus
{
}

public class ReportTypeResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

public class ReportTypesResponse
{
    public ReportTypeResponse[] ReportTypes { get; set; }
}

public class ArtistImageSearchResponse
{
    public int ResultCount { get; set; }

    public ArtistAssetSearchItem[] Images { get; set; }
}

public class ArtistVideoSearchResponse
{
    public int ResultCount { get; set; }

    public ArtistAssetSearchItem[] Videos { get; set; }
}

public class ArtistAssetSearchItem
{
    public AllowedUse AllowedUse { get; set; }

    public Dictionary<string, string> AlternativeIds { get; set; }

    public string Artist { get; set; }

    public string AssetFamily { get; set; }

    public string AssetType { get; set; }

    public bool CallForImage { get; set; }

    public string Caption { get; set; }

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

public class ArtistAssetSearchKeyword
{
    public string KeywordId { get; set; }

    public string Text { get; set; }

    public string Type { get; set; }
}

public class GetVideoMetadataResponse
{
    public Video[] Videos { get; set; }
    public string[] VideosNotFound { get; set; }
}
public class Video
{
    public string Id { get; set; }
    public AssetDetailAllowedUse AllowedUse { get; set; }
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

public class VideoDownloadSize
{
    public string BitDepth { get; set; }
    public string Compression { get; set; }
    public string ContentType { get; set; }
    public string Description { get; set; }
    
    public Download[] Downloads { get; set; }
    public string Format { get; set; }
    public double FrameRate { get; set; }
    public string FrameSize { get; set; }
    public decimal Height { get; set; }
    public bool Interlaced { get; set; }
    public long Bytes { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
}