using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.AiGenerator;
using GettyImages.Api.Artists;
using GettyImages.Api.AssetChanges;
using GettyImages.Api.AssetLicensing;
using GettyImages.Api.Boards;
using GettyImages.Api.Download;
using GettyImages.Api.Images;
using GettyImages.Api.Purchases;
using GettyImages.Api.Search;
using GettyImages.Api.Usage;
using GettyImages.Api.Videos;

namespace GettyImages.Api;

/// <summary>
///     Main entry point to the Getty Images API SDK
/// </summary>
public class ApiClient
{
    private const string Slash = "/";
    private const string DefaultApiUri = "https://api.gettyimages.com/v3";
    private const string AuthApiUrl = "https://authentication.gettyimages.com";
    private readonly Credentials _credentials;
    private readonly DelegatingHandler _customHandler;
    private string _baseUrl;

    private ApiClient(string baseUrl, DelegatingHandler customHandler)
    {
        _customHandler = customHandler;
        NormalizeAndSetBaseUrl(baseUrl);
    }

    private ApiClient(string apiKey,
        string baseUrl, DelegatingHandler customHandler) : this(baseUrl, customHandler)
    {
        _customHandler = customHandler;
        _credentials = Credentials.GetInstance(apiKey, AuthApiUrl);
    }

    private ApiClient(string apiKey, string apiSecret, string refreshToken,
        string baseUrl, DelegatingHandler customHandler) : this(baseUrl, customHandler)
    {
        _customHandler = customHandler;
        _credentials = Credentials.GetInstance(apiKey, apiSecret, refreshToken, AuthApiUrl);
    }

    private ApiClient(string apiKey, string apiSecret, string baseUrl, DelegatingHandler customHandler)
        : this(baseUrl, customHandler)
    {
        _customHandler = customHandler;
        _credentials = Credentials.GetInstance(apiKey, apiSecret, AuthApiUrl);
    }

    private ApiClient(string apiKey, string apiSecret, string userName, string userPassword,
        string baseUrl, DelegatingHandler customHandler)
        : this(baseUrl, customHandler)
    {
        _customHandler = customHandler;
        _credentials = Credentials.GetInstance(apiKey, apiSecret, userName, userPassword, AuthApiUrl);
    }

    public static ApiClient GetApiClientWithApiKey(string apiKey, DelegatingHandler customHandler = null)
    {
        return new ApiClient(apiKey, DefaultApiUri, customHandler);
    }

    public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret)
    {
        return new ApiClient(apiKey, apiSecret, DefaultApiUri, null);
    }

    public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
        string userName, string userPassword)
    {
        return new ApiClient(apiKey, apiSecret, userName, userPassword, DefaultApiUri, null);
    }

    public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken)
    {
        return new ApiClient(apiKey, apiSecret, refreshToken, DefaultApiUri, null);
    }

    public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret,
        string baseUrl)
    {
        return new ApiClient(apiKey, apiSecret, baseUrl, null);
    }

    public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
        string userName, string userPassword,
        string baseUrl)
    {
        return new ApiClient(apiKey, apiSecret, userName, userPassword, baseUrl, null);
    }

    public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken,
        string baseUrl)
    {
        return new ApiClient(apiKey, apiSecret, refreshToken, baseUrl, null);
    }

    public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret,
        DelegatingHandler customHandler)
    {
        return new ApiClient(apiKey, apiSecret, DefaultApiUri, customHandler);
    }

    public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
        string userName, string userPassword, DelegatingHandler customHandler)
    {
        return new ApiClient(apiKey, apiSecret, userName, userPassword, DefaultApiUri, customHandler);
    }

    public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken,
        DelegatingHandler customHandler)
    {
        return new ApiClient(apiKey, apiSecret, refreshToken, DefaultApiUri, customHandler);
    }

    /// <summary>
    ///     Gets an access token using the credentials used to construct the <see cref="ApiClient" />
    /// </summary>
    /// <returns>
    ///     The <see cref="Token" />
    /// </returns>
    public async Task<Token> GetAccessToken()
    {
        return await _credentials.GetAccessToken();
    }

    private void NormalizeAndSetBaseUrl(string baseUrl)
    {
        _baseUrl = baseUrl.EndsWith(Slash) ? baseUrl.Remove(baseUrl.Length - 1) : baseUrl;
    }

    /// <summary>
    ///     Search for creative images only
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchImagesCreative" />.
    /// </returns>
    public SearchImagesCreative SearchImagesCreative()
    {
        return Search.SearchImagesCreative.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for creative images based on an image
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchImagesCreativeByImage" />.
    /// </returns>
    public SearchImagesCreativeByImage SearchImagesCreativeByImage()
    {
        return Search.SearchImagesCreativeByImage.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for editorial images only
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchImagesEditorial" />.
    /// </returns>
    public SearchImagesEditorial SearchImagesEditorial()
    {
        return Search.SearchImagesEditorial.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for creative videos
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchVideosCreative" />.
    /// </returns>
    public SearchVideosCreative SearchVideosCreative()
    {
        return Search.SearchVideosCreative.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for creative videos based on an image
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchImagesCreativeByImage" />.
    /// </returns>
    public SearchVideosCreativeByImage SearchVideosCreativeByImage()
    {
        return Search.SearchVideosCreativeByImage.GetInstance(_credentials, _baseUrl, _customHandler);
    }
    
    /// <summary>
    ///     Search for editorial videos
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.SearchVideosEditorial" />.
    /// </returns>
    public SearchVideosEditorial SearchVideosEditorial()
    {
        return Search.SearchVideosEditorial.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for events
    /// </summary>
    /// <returns>
    ///     The <see cref="Search.Events" />.
    /// </returns>
    public Search.Events SearchEvents()
    {
        return Search.Events.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Returns information about a customer's download assets
    /// </summary>
    /// <returns>
    ///     The <see cref="Download.Downloads" />.
    /// </returns>
    public Downloads Downloads()
    {
        return Download.Downloads.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Download an image
    /// </summary>
    /// <returns>
    ///     The <see cref="Download.DownloadsImages" />.
    /// </returns>
    public DownloadsImages DownloadsImages()
    {
        return Download.DownloadsImages.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Download a video
    /// </summary>
    /// <returns>
    ///     The <see cref="Download.DownloadsVideos" />.
    /// </returns>
    public DownloadsVideos DownloadsVideos()
    {
        return Download.DownloadsVideos.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get products
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Products.Products" />.
    /// </returns>
    public Products.Products Products()
    {
        return Api.Products.Products.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get countries codes and names
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Countries.Countries" />.
    /// </returns>
    public Countries.Countries Countries()
    {
        return Api.Countries.Countries.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get collections applicable for the customer
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Collections.Collections" />.
    /// </returns>
    public Collections.Collections Collections()
    {
        return Api.Collections.Collections.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for images by a photographer
    /// </summary>
    /// <returns>
    ///     The <see cref="Artists.ArtistsImages" />.
    /// </returns>
    public ArtistsImages ArtistsImages()
    {
        return Artists.ArtistsImages.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for videos by a photographer
    /// </summary>
    /// <returns>
    ///     The <see cref="Artists.ArtistsVideos" />.
    /// </returns>
    public ArtistsVideos ArtistsVideos()
    {
        return Artists.ArtistsVideos.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get metadata for events
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Events.Events" />.
    /// </returns>
    public Events.Events Events()
    {
        return Api.Events.Events.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get metadata for images
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Images.Images" />.
    /// </returns>
    public Images.Images Images()
    {
        return Api.Images.Images.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for images similar to an image
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Images.ImagesSimilar" />.
    /// </returns>
    public ImagesSimilar ImagesSimilar()
    {
        return Api.Images.ImagesSimilar.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for images in same series as an image
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Images.ImagesSameSeries" />.
    /// </returns>
    public ImagesSameSeries ImagesSameSeries()
    {
        return Api.Images.ImagesSameSeries.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get download history for single image
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Images.ImageDownloadHistory" />.
    /// </returns>
    public ImageDownloadHistory ImageDownloadHistory()
    {
        return Api.Images.ImageDownloadHistory.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get metadata for videos
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Videos.Videos" />.
    /// </returns>
    public Videos.Videos Videos()
    {
        return Api.Videos.Videos.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for videos similar to a video
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Videos.VideosSimilar" />.
    /// </returns>
    public VideosSimilar VideosSimilar()
    {
        return Api.Videos.VideosSimilar.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Search for videos in same series as a video
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Videos.VideosSameSeries" />.
    /// </returns>
    public VideosSameSeries VideosSameSeries()
    {
        return Api.Videos.VideosSameSeries.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get download history for a single video
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Videos.VideoDownloadHistory" />.
    /// </returns>
    public VideoDownloadHistory VideoDownloadHistory()
    {
        return Api.Videos.VideoDownloadHistory.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get previously purchased images and videos
    /// </summary>
    /// <returns>
    ///     The <see cref="Purchases.PurchasedAssets" />.
    /// </returns>
    public PurchasedAssets PurchasedAssets()
    {
        return Purchases.PurchasedAssets.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Report usage of assets via a batch format
    /// </summary>
    /// <returns>
    ///     The <see cref="Usage.UsageBatches" />.
    /// </returns>
    public UsageBatches UsageBatches()
    {
        return Usage.UsageBatches.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get asset change notifications
    /// </summary>
    /// <returns>
    ///     The <see cref="AssetChanges.ChangeSets" />.
    /// </returns>
    public ChangeSets ChangeSets()
    {
        return AssetChanges.ChangeSets.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Confirm asset change notifications
    /// </summary>
    /// <returns>
    ///     The <see cref="AssetChanges.DeleteAssetChanges" />.
    /// </returns>
    public DeleteAssetChanges DeleteAssetChanges()
    {
        return AssetChanges.DeleteAssetChanges.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get a list of asset change notification channels
    /// </summary>
    /// <returns>
    ///     The <see cref="AssetChanges.Channels" />.
    /// </returns>
    public Channels Channels()
    {
        return AssetChanges.Channels.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get all boards that the user participates in
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.GetBoards" />.
    /// </returns>
    public GetBoards GetBoards()
    {
        return Boards.GetBoards.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Create a new board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.PostBoards" />.
    /// </returns>
    public PostBoards PostBoards()
    {
        return Boards.PostBoards.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Delete a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.DeleteBoardsById" />.
    /// </returns>
    public DeleteBoardsById DeleteBoardsById()
    {
        return Boards.DeleteBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get assets and metadata for a specific board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.GetBoardsById" />.
    /// </returns>
    public GetBoardsById GetBoardsById()
    {
        return Boards.GetBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Update a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.PutBoardsById" />.
    /// </returns>
    public PutBoardsById PutBoardsById()
    {
        return Boards.PutBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Remove assets from a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.DeleteAssets" />.
    /// </returns>
    public DeleteAssets DeleteAssets()
    {
        return Boards.DeleteAssets.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Add assets to a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.PutAssets" />.
    /// </returns>
    public PutAssets PutAssets()
    {
        return Boards.PutAssets.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Remove an asset from a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.DeleteAssetsById" />.
    /// </returns>
    public DeleteAssetsById DeleteAssetsById()
    {
        return Boards.DeleteAssetsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Add an asset to a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.PutAssetsById" />.
    /// </returns>
    public PutAssetsById PutAssetsById()
    {
        return Boards.PutAssetsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get comments from a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.GetComments" />.
    /// </returns>
    public GetComments GetComments()
    {
        return Boards.GetComments.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Add a comment to a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.PostComments" />.
    /// </returns>
    public PostComments PostComments()
    {
        return Boards.PostComments.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Delete a comment from a board
    /// </summary>
    /// <returns>
    ///     The <see cref="Boards.DeleteCommentsById" />.
    /// </returns>
    public DeleteCommentsById DeleteCommentsById()
    {
        return Boards.DeleteCommentsById.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Get order metadata
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Orders.Orders" />.
    /// </returns>
    public Orders.Orders Orders()
    {
        return Api.Orders.Orders.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Acquire extended licenses with iStock credits for an asset.
    /// </summary>
    /// <returns>
    ///     The <see cref="AssetLicensing.AcquireExtendedLicense" />.
    /// </returns>
    public AcquireExtendedLicense AcquireExtendedLicense()
    {
        return AssetLicensing.AcquireExtendedLicense.GetInstance(_credentials, _baseUrl, _customHandler);
    }

    /// <summary>
    ///     Returns information about the current user
    /// </summary>
    /// <returns>
    ///     The <see cref="Api.Customers.Customers" />.
    /// </returns>
    public Customers.Customers Customers()
    {
        return Api.Customers.Customers.GetInstance(_credentials, _baseUrl, _customHandler);
    }
    
// TODO - Naming?
    /// <summary>
    ///     Generate images
    /// </summary>
    /// <returns>
    ///     The <see cref="AiGenerator.ImageGenerations" />.
    /// </returns>
    public ImageGenerations ImageGenerations()
    {
        return AiGenerator.ImageGenerations.GetInstance(_credentials, _baseUrl, _customHandler);
    }
    
// TODO - Naming?
    /// <summary>
    ///     Get generated images
    /// </summary>
    /// <returns>
    ///     The <see cref="AiGenerator.GetGeneratedImages" />.
    /// </returns>
    public GetGeneratedImages GetGeneratedImages()
    {
        return AiGenerator.GetGeneratedImages.GetInstance(_credentials, _baseUrl, _customHandler);
    }
    
// TODO - Naming?
    /// <summary>
    ///     Get generated image download
    /// </summary>
    /// <returns>
    ///     The <see cref="AiGenerator.GetGeneratedImageDownload" />.
    /// </returns>
    public GetGeneratedImageDownload GetGeneratedImageDownload()
    {
        return AiGenerator.GetGeneratedImageDownload.GetInstance(_credentials, _baseUrl, _customHandler);
    }
}