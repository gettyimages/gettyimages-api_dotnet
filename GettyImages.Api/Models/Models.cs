using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GettyImages.Api.Entity;

// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public partial class AffiliateSearchStyle
{
}

public partial class AffiliateImageUrls
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

public partial class AffiliateImage
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public AffiliateImageUrls PreviewUrls { get; set; }

    public string DestinationUrl { get; set; }
}

public partial class AutoCorrections
{
    public string Phrase { get; set; }
}

public partial class AffiliateImageSearchResponse
{
    public AffiliateImage[] Images { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
}

public partial class AffiliateVideoUrls
{
    public string SmallStill { get; set; }

    public string MediumStill { get; set; }

    public string LargeStill { get; set; }

    public string SmallMotion { get; set; }

    public string LargeMotion { get; set; }
}

public partial class AffiliateVideo
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Caption { get; set; }

    public AffiliateVideoUrls PreviewUrls { get; set; }

    public string DestinationUrl { get; set; }

    public string ClipLength { get; set; }
}

public partial class AffiliateVideoSearchResponse
{
    public AffiliateVideo[] Videos { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
}

public partial class ArtistsImageSearchFieldValues
{
}

public partial class ArtistsVideoSearchFieldValues
{
}

public enum ExtendedLicense
{
    Multiseat,
    Unlimited,
    Resale,
    Indemnification
}

public partial class AcquireAssetLicensesRequest
{
    public ExtendedLicense[] ExtendedLicenses { get; set; }

    public bool UseTeamCredits { get; set; }
}

public partial class AssetLicensingResponse
{
    public int CreditsUsed { get; set; }

    public ExtendedLicense[] AcquiredLicenses { get; set; }
}

public partial class AssetEvent
{
    public DateTime Timestamp { get; set; }

    public string AssetId { get; set; }

    public string EmailAddress { get; set; }
}

public partial class GetSendEventsResponse
{
    public DateTime LastOffset { get; set; }

    public AssetEvent[] AssetSendEvents { get; set; }
}

public partial class Collection
{
    public string AssetFamily { get; set; }

    public string Code { get; set; }

    public int Id { get; set; }

    public string LicenseModel { get; set; }

    public string Name { get; set; }

    public string[] ProductTypes { get; set; }
}

public partial class GetCollectionsResponse
{
    public Collection[] Collections { get; set; }
}

public partial class Country
{
    [JsonPropertyName("iso_alpha_2")] public string IsoAlpha2 { get; set; }

    [JsonPropertyName("iso_alpha_3")] public string IsoAlpha3 { get; set; }

    public string Name { get; set; }
}

public partial class CountriesList
{
    public Country[] Countries { get; set; }
}

public partial class CuratedSet
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

public partial class CustomerInfoResponse
{
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }
}

public partial class LogLevel
{
}

public partial class MemcachedLogEntry
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

public partial class DownloadFileType
{
}

public partial class ProductTypeRequest
{
}

public partial class PremiumAccessDownloadData
{
    public string DownloadNotes { get; set; }

    public string ProjectCode { get; set; }
}

public partial class DownloadDetails
{
    public string DownloadNotes { get; set; }

    public string ProjectCode { get; set; }
}

public partial class User
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }
}

public partial class Dimensions
{
    public int Width { get; set; }

    public int Height { get; set; }

    public int Dpi { get; set; }
}

public partial class HistoricalDownload
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

public partial class GetDownloadsResponse
{
    public int ResultCount { get; set; }

    public HistoricalDownload[] Downloads { get; set; }
}

public partial class EventDetailFieldValues
{
}

public partial class ImageDetailFieldValues
{
}

public partial class ImagesDetailResponse
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
    public int Height { get; set; }
    public string MediaType { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Dpi { get; set; }
}

public partial class ImagesFieldValues
{
}

public partial class AllowedUse
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

public partial class Contributor
{
    public string MemberName { get; set; }

    public string DisplayName { get; set; }
}

public partial class AssetSearchItemDisplaySize
{
    public bool IsWatermarked { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }
}

public partial class Keyword
{
    public string KeywordId { get; set; }

    public string Text { get; set; }

    public string Type { get; set; }

    public int? Relevance { get; set; }

    public string[] EntityUris { get; set; }

    public string[] EntityTypes { get; set; }
}

public partial class Download
{
    public string ProductId { get; set; }

    public string ProductType { get; set; }

    public string Uri { get; set; }

    public string AgreementName { get; set; }
}

public partial class MaxDimensions
{
    public int Height { get; set; }

    public int Width { get; set; }
}

public partial class ReferralDestination
{
    public string SiteName { get; set; }

    public string Uri { get; set; }
}

public partial class TerritoryRestriction
{
    public string CountryCode { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }
}

public partial class IStockLicense
{
    public string LicenseType { get; set; }

    public int Credits { get; set; }
}

public partial class ImageSearchItem
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

public partial class RelatedSearch
{
    public string Phrase { get; set; }

    public string Url { get; set; }
}

public partial class ImageSearchItemSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItem[] Images { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class AssetDownloadHistoryResults
{
    public string Id { get; set; }
}

public partial class OrderNotes
{
    public string LicenseeName { get; set; }

    public string PurchaseOrderNumber { get; set; }

    public string ProjectTitle { get; set; }

    public string OrderedBy { get; set; }
}

public partial class AssetIdFromOrder
{
    public string Id { get; set; }
}

public partial class OrderDetail
{
    public string Id { get; set; }

    public string InvoiceNumber { get; set; }

    public DateTime OrderDate { get; set; }

    public string EndClient { get; set; }

    public OrderNotes Notes { get; set; }

    public AssetIdFromOrder[] Assets { get; set; }
}

public partial class ProductStatusRequest
{
}

public partial class ProductFieldValues
{
}

public partial class ProductStatus
{
}

public partial class ProductTypeResponse
{
}

public partial class DownloadRequirements
{
    public bool IsNoteRequired { get; set; }

    public bool IsProjectCodeRequired { get; set; }

    public string[] ProjectCodes { get; set; }
}

public partial class OverageDetails
{
    public int Limit { get; set; }

    public int Remaining { get; set; }

    public int Count { get; set; }

    public bool OveragesReached { get; set; }
}

public partial class Product
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

public partial class GetProductsResponse
{
    public Product[] Products { get; set; }
}

public partial class PreviousPurchase
{
    public DateTime DatePurchased { get; set; }

    public string ImageId { get; set; }

    public string LicenseModel { get; set; }

    public string OrderId { get; set; }

    public string ThumbUri { get; set; }
}

public partial class PreviousPurchase
{
    public int ResultCount { get; set; }

    public PreviousPurchase[] PreviousPurchases { get; set; }
}

public partial class PreviousAssetPurchase
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

public partial class GetPreviouslyPurchasedAssetsResponse
{
    public int ResultCount { get; set; }

    public PreviousAssetPurchase[] PreviousPurchases { get; set; }
}

public partial class AgeOfPeopleFilterType
{
}

public partial class CollectionsFilterType
{
}

public partial class CompositionsFilterType
{
}

public partial class EthnicityFilterType
{
}

public partial class SearchFileType
{
}

public partial class GraphicalStyle
{
}

public partial class GraphicalStylesFilterType
{
}

public partial class LicenseModelImageRequest
{
}

public partial class TeeShirtSize
{
}

public partial class NumberOfPeopleFilterType
{
}

public partial class OrientationRequest
{
}

public partial class BlendedImageSortOrder
{
}

public partial class CreativeImagesFieldValues
{
}

public partial class CreativeImageSortOrder
{
}

public partial class CreateImageSearchFacetsFields
{
}

public partial class ImageSearchItemCreative
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

public partial class CreativeImageSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItemCreative[] Images { get; set; }

    public AutoCorrections AutoCorrections { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class SpecificPeople
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public partial class FacetEvent
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Date { get; set; }
}

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public partial class Artist
{
    public string Name { get; set; }
}

public partial class Entertainment
{
    public int Id { get; set; }

    public string Name { get; set; }
}

public partial class SearchFacetsResponse
{
    public SpecificPeople[] SpecificPeople { get; set; }

    public FacetEvent[] Events { get; set; }

    public Location[] Locations { get; set; }

    public Artist[] Artists { get; set; }

    public Entertainment[] Entertainment { get; set; }
}

public partial class SearchByImageResourceResults
{

    public RelatedSearch[] RelatedSearches { get; set; }

    public int ResultCount { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public AutoCorrections AutoCorrections { get; set; }
    
    public ImageSearchItemCreative[] Images { get; set; }
}

public partial class EditorialSegmentContract
{
}

public partial class EditorialImagesFieldValues
{
}

public partial class EditorialGraphicalStyle
{
}

public partial class SortOrder
{
}

public partial class EditorialImageSearchFacetsFields
{
}

public partial class EditorialSource
{
    public int Id { get; set; }
}

public partial class ImageSearchItemEditorial
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

public partial class EditorialImageSearchResults
{
    public int ResultCount { get; set; }

    public ImageSearchItemEditorial[] Images { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class VideoAspectRatioFilterType
{
}

public partial class EditorialVideoType
{
}

public partial class VideoFormatsRequest
{
}

public partial class VideoFrameRates
{
}

public partial class BlendedVideosFieldValues
{
}

public partial class LicenseModelVideoRequest
{
}

public partial class VideoOrientationRequest
{
}

public partial class ReleaseStatus
{
}

public partial class VideoSearchItemDisplaySize
{
    public bool IsWatermarked { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }

    public string AspectRatio { get; set; }
}

public partial class BlendedVideoSearchItem
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

public partial class BlendedVideoSearchResults
{
    public int ResultCount { get; set; }

    public BlendedVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class CreativeVideosFieldValues
{
}

public partial class ImageTechniquesFilterType
{
}

public partial class CreativeVideoSortOrder
{
}

public partial class CreateVideoSearchFacetsFields
{
}

public partial class ViewpointsFilterType
{
}

public partial class CreativeVideoSearchItem
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

public partial class CreativeVideoSearchResults
{
    public int ResultCount { get; set; }

    public CreativeVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public AutoCorrections AutoCorrections { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class EditorialVideosFieldValues
{
}

public partial class EditorialVideoSearchFacetsFields
{
}

public partial class EditorialVideoSearchItem
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

public partial class EditorialVideoSearchResults
{
    public int ResultCount { get; set; }

    public EditorialVideoSearchItem[] Videos { get; set; }

    public SearchFacetsResponse Facets { get; set; }

    public RelatedSearch[] RelatedSearches { get; set; }
}

public partial class EventFieldValues
{
}

public partial class EventSearchSortOrder
{
}

public partial class HeroImageDisplaySize
{
    public string Name { get; set; }

    public bool IsWatermarked { get; set; }

    public string Uri { get; set; }
}

public partial class HeroImage
{
    public string Id { get; set; }

    public HeroImageDisplaySize[] DisplaySizes { get; set; }
}

public partial class LocationEvent
{
    public string City { get; set; }

    public string Country { get; set; }

    public string StateProvince { get; set; }

    public string Venue { get; set; }
}

public partial class Event
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

public partial class EventsSearchResult
{
    public Event[] Events { get; set; }

    public int ResultCount { get; set; }
}

public class GetEventsResponse
{
    public Event[] Events { get; set; }
    public int[] EventsNotFound { get; set; }
}

public partial class VideoDetailFieldValues
{
}

public partial class AssetUsage
{
    public string AssetId { get; set; }

    public int Quantity { get; set; }

    public DateTime UsageDate { get; set; }
}

public partial class ReportUsageBatchRequest
{
    public AssetUsage[] AssetUsages { get; set; }
}

public partial class ReportUsageBatchResponse
{
    public string[] InvalidAssets { get; set; }

    public int TotalAssetUsagesProcessed { get; set; }
}

public partial class ChangedAssetDetail
{
    public DateTime AssetChangedUtcDatetime { get; set; }

    public string AssetLifecycle { get; set; }

    public string AssetType { get; set; }

    public string Id { get; set; }

    public string Uri { get; set; }
}

public partial class AssetChanges
{
    public string ChangeSetId { get; set; }

    public ChangedAssetDetail[] ChangedAssets { get; set; }
}

public partial class AssetFamily
{
}

public partial class AssetType
{
}

public partial class Channel
{
    public int ChannelId { get; set; }

    public string AssetFamily { get; set; }

    public string ChannelType { get; set; }

    public DateTime StartDate { get; set; }

    public int NotificationCount { get; set; }

    public string AssetType { get; set; }

    public DateTime OldestNotificationDateUtc { get; set; }
}

public partial class BoardRelationship
{
}

public partial class BoardSortOrder
{
}

public partial class DisplaySize
{
    public string Name { get; set; }

    public string Uri { get; set; }
}

public partial class Asset
{
    public string Id { get; set; }

    public string AssetType { get; set; }

    public DateTime DateAdded { get; set; }

    public DisplaySize[] DisplaySizes { get; set; }
}

public partial class GetBoardsResponse
{
    public BoardBasic[] Boards { get; set; }

    public int BoardCount { get; set; }
}

public partial class BoardInfo
{
    public string Name { get; set; }

    public string Description { get; set; }
}

public partial class CreateBoardResponse
{
    public string Id { get; set; }
}

public partial class BoardPermissions
{
    public bool CanDeleteBoard { get; set; }

    public bool CanInviteToBoard { get; set; }

    public bool CanUpdateName { get; set; }

    public bool CanUpdateDescription { get; set; }

    public bool CanAddAssets { get; set; }

    public bool CanRemoveAssets { get; set; }
}

public partial class Links
{
    public string Invitation { get; set; }

    public string Share { get; set; }
}

public partial class BoardBasic
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

public partial class BoardDetail
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

public partial class BoardAsset
{
    public string AssetId { get; set; }
}

public partial class AddBoardAssetsResult
{
    public BoardAsset[] AssetsAdded { get; set; }

    public string[] AssetsNotAdded { get; set; }
}

public partial class Collaborator
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

public partial class CommentPermissions
{
    public bool CanDeleteComment { get; set; }
}

public partial class Comment
{
    public Collaborator CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public string Id { get; set; }

    public CommentPermissions Permissions { get; set; }

    public string Text { get; set; }
}

public partial class BoardCommentPermissions
{
    public bool CanAddComment { get; set; }
}

public partial class GetCommentsResponse
{
    public Comment[] Comments { get; set; }

    public BoardCommentPermissions Permissions { get; set; }
}

public partial class CommentRequest
{
    public string Text { get; set; }
}

public partial class CreateCommentResponse
{
    public string Id { get; set; }
}

public partial class SelfResult
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}

public partial class CreateReportRequest
{
    public string ReportTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

public partial class ProblemDetails
{
    public string Type { get; set; }

    public string Title { get; set; }

    public int Status { get; set; }

    public string Detail { get; set; }

    public string Instance { get; set; }
}

public partial class ReportMetadataResponse
{
    public string Id { get; set; }

    public string ReportStatus { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}

public partial class ReportsMetadataResponse
{
    public ReportMetadataResponse[] Reports { get; set; }
}

public partial class ReportStatus
{
}

public partial class ReportTypeResponse
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

public partial class ReportTypesResponse
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

public partial class ArtistAssetSearchItem
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

public partial class ArtistAssetSearchKeyword
{
    public string KeywordId { get; set; }

    public string Text { get; set; }

    public string Type { get; set; }
}
