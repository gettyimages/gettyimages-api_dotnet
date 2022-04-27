// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GettyImages.Api.Models;

public class AutoCorrections
{
    public string Phrase { get; set; }
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
public class GetCountriesResponse
{
    public Country[] Countries { get; set; }
}
public class CustomerInfoResponse
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}
public class DownloadAssetResponse
{
    public string Uri { get; set; }
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
public class GetImagesDetailsResponse
{
    public ImageDetail[] Images { get; set; }
    public string[] ImagesNotFound { get; set; }
}
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
public class ArtistAssetSearchAllowedUse
{
    [JsonPropertyName("HowCanIUseIt")] public string HowCanIUseIt { get; set; }
    [JsonPropertyName("ReleaseInfo")] public string ReleaseInfo { get; set; }
    [JsonPropertyName("UsageRestrictions")] public string[] UsageRestrictions { get; set; }
    [JsonPropertyName("Code")] public string Code { get; set; }
}
public class AllowedUse
{
    public string HowCanIUseIt { get; set; }
    public string ReleaseInfo { get; set; }
    public string[] UsageRestrictions { get; set; }
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
// ReSharper disable once InconsistentNaming
public class IStockLicense
{
    public string LicenseType { get; set; }
    public int Credits { get; set; }
}
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
public class RelatedSearch
{
    public string Phrase { get; set; }
    public string Url { get; set; }
}
public class GetSimilarImagesResponse
{
    public int ResultCount { get; set; }
    public ImageSearchItem[] Images { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}
public class GetAssetDownloadHistoryResponse
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
public class ImageSearchItemCreative
{
    public AllowedUse AllowedUse { get; set; }
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
public class SearchCreativeImagesResponse
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
public class SearchCreativeImagesByImageResponse
{
    public RelatedSearch[] RelatedSearches { get; set; }
    public int ResultCount { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public AutoCorrections AutoCorrections { get; set; }
    public ImageSearchItemCreative[] Images { get; set; }
}
public class EditorialSource
{
    public int Id { get; set; }
}
public class ImageSearchItemEditorial
{
    public AllowedUse AllowedUse { get; set; }
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
public class SearchEditorialImagesResponse
{
    public int ResultCount { get; set; }
    public ImageSearchItemEditorial[] Images { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}
public class VideoSearchItemDisplaySize
{
    public bool IsWatermarked { get; set; }
    public string Name { get; set; }
    public string Uri { get; set; }
    public string AspectRatio { get; set; }
}
public class CreativeVideoSearchItem
{
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
public class SearchCreativeVideosResponse
{
    public int ResultCount { get; set; }
    public CreativeVideoSearchItem[] Videos { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public AutoCorrections AutoCorrections { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
}
public class EditorialVideoSearchItem
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
public class SearchEditorialVideosResponse
{
    public int ResultCount { get; set; }
    public EditorialVideoSearchItem[] Videos { get; set; }
    public SearchFacetsResponse Facets { get; set; }
    public RelatedSearch[] RelatedSearches { get; set; }
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
public class SearchEventsResponse
{
    public Event[] Events { get; set; }
    public int ResultCount { get; set; }
}
public class GetEventsResponse
{
    public Event[] Events { get; set; }
    public int[] EventsNotFound { get; set; }
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
public class AddBoardAssetsResponse
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
public class SearchImagesByArtistResponse
{
    public int ResultCount { get; set; }
    public ArtistAssetSearchItem[] Images { get; set; }
}
public class SearchVideosByArtistResponse
{
    public int ResultCount { get; set; }
    public ArtistAssetSearchItem[] Videos { get; set; }
}
public class ArtistAssetSearchItem
{
    public ArtistAssetSearchAllowedUse AllowedUse { get; set; }
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
public class GetVideosDetailsResponse
{
    public Video[] Videos { get; set; }
    public string[] VideosNotFound { get; set; }
}
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

public class OAuthResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string ExpiresIn { get; set; }
}