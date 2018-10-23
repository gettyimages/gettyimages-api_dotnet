using System;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Download;
using GettyImages.Api.Orders;
using GettyImages.Api.Search;

namespace GettyImages.Api
{
    /// <summary>
    ///     Main entry point to the Getty Images API SDK
    /// </summary>
    public class ApiClient
    {
        private readonly DelegatingHandler _customHandler;
        private const string Slash = "/";
        private const string DefaultApiUri = "https://api.gettyimages.com/v3";
        private readonly Credentials _credentials;
        private string _baseUrl;

        private ApiClient(string baseUrl, DelegatingHandler customHandler)
        {
            _customHandler = customHandler;
            NormalizeAndSetBaseUrl(baseUrl);
        }

        private ApiClient(string apiKey, string apiSecret, string refreshToken,
            string baseUrl, DelegatingHandler customHandler) : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, refreshToken, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string baseUrl, DelegatingHandler customHandler)
            : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, GetOAuthBaseUrl());
        }

        private ApiClient(string apiKey, string apiSecret, string userName, string userPassword,
            string baseUrl, DelegatingHandler customHandler)
            : this(baseUrl, customHandler)
        {
            _customHandler = customHandler;
            _credentials = Credentials.GetInstance(apiKey, apiSecret, userName, userPassword, GetOAuthBaseUrl());
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


        public static ApiClient GetApiClientWithClientCredentials(string apiKey, string apiSecret, DelegatingHandler customHandler)
        {
            return new ApiClient(apiKey, apiSecret, DefaultApiUri, customHandler);
        }

        public static ApiClient GetApiClientWithResourceOwnerCredentials(string apiKey, string apiSecret,
            string userName, string userPassword, DelegatingHandler customHandler)
        {
            return new ApiClient(apiKey, apiSecret, userName, userPassword, DefaultApiUri, customHandler);
        }

        public static ApiClient GetApiClientWithRefreshToken(string apiKey, string apiSecret, string refreshToken, DelegatingHandler customHandler)
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

        private string GetOAuthBaseUrl()
        {
            var oAuthBaseUrl = _baseUrl.Substring(0, _baseUrl.LastIndexOf(Slash, StringComparison.Ordinal));
            return oAuthBaseUrl;
        }

        /// <summary>
        ///     Search for both creative and editorial images
        /// </summary>
        /// <returns>
        ///     The <see cref="Search.SearchImages" />.
        /// </returns>
        public SearchImages SearchImages()
        {
            return Search.SearchImages.GetInstance(_credentials, _baseUrl, _customHandler);
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
        ///     Search for creative images based on url
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
        ///     Search for both creative and editorial videos
        /// </summary>
        /// <returns>
        ///     The <see cref="Search.SearchVideos" />.
        /// </returns>
        public SearchVideos SearchVideos()
        {
            return Search.SearchVideos.GetInstance(_credentials, _baseUrl, _customHandler);
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
        ///     The <see cref="Search.Products" />.
        /// </returns>
        public Search.Products SearchEvents()
        {
            return Search.Products.GetInstance(_credentials, _baseUrl, _customHandler);
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
        public Artists.ArtistsImages ArtistsImages()
        {
            return Artists.ArtistsImages.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Search for videos by a photographer
        /// </summary>
        /// <returns>
        ///     The <see cref="Artists.ArtistsVideos" />.
        /// </returns>
        public Artists.ArtistsVideos ArtistsVideos()
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
        public Images.ImagesSimilar ImagesSimilar()
        {
            return Api.Images.ImagesSimilar.GetInstance(_credentials, _baseUrl, _customHandler);
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
        public Videos.VideosSimilar VideosSimilar()
        {
            return Api.Videos.VideosSimilar.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get previously purchased images and videos
        /// </summary>
        /// <returns>
        ///     The <see cref="Purchases.PurchasedAssets" />.
        /// </returns>
        public Purchases.PurchasedAssets PurchasedAssets()
        {
            return Purchases.PurchasedAssets.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get previously purchased images
        /// </summary>
        /// <returns>
        ///     The <see cref="Purchases.PurchasedImages" />.
        /// </returns>
        public Purchases.PurchasedImages PurchasedImages()
        {
            return Purchases.PurchasedImages.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Register a list of customer assets
        /// </summary>
        /// <returns>
        ///     The <see cref="AssetRegistration.AssetRegistrations" />.
        /// </returns>
        public AssetRegistration.AssetRegistrations AssetRegistrations()
        {
            return AssetRegistration.AssetRegistrations.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Report usage of assets via a batch format
        /// </summary>
        /// <returns>
        ///     The <see cref="Usage.UsageBatches" />.
        /// </returns>
        public Usage.UsageBatches UsageBatches()
        {
            return Usage.UsageBatches.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get asset change notifications
        /// </summary>
        /// <returns>
        ///     The <see cref="AssetChanges.ChangeSets" />.
        /// </returns>
        public AssetChanges.ChangeSets ChangeSets()
        {
            return AssetChanges.ChangeSets.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Confirm asset change notifications
        /// </summary>
        /// <returns>
        ///     The <see cref="AssetChanges.DeleteAssetChanges" />.
        /// </returns>
        public AssetChanges.DeleteAssetChanges DeleteAssetChanges()
        {
            return AssetChanges.DeleteAssetChanges.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get a list of asset change notification channels
        /// </summary>
        /// <returns>
        ///     The <see cref="AssetChanges.Channels" />.
        /// </returns>
        public AssetChanges.Channels Channels()
        {
            return AssetChanges.Channels.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get all boards that the user participates in
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.GetBoards" />.
        /// </returns>
        public Boards.GetBoards GetBoards()
        {
            return Boards.GetBoards.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Create a new board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.PostBoards" />.
        /// </returns>
        public Boards.PostBoards PostBoards()
        {
            return Boards.PostBoards.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Delete a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.DeleteBoardsById" />.
        /// </returns>
        public Boards.DeleteBoardsById DeleteBoardsById()
        {
            return Boards.DeleteBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get assets and metadata for a specific board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.GetBoardsById" />.
        /// </returns>
        public Boards.GetBoardsById GetBoardsById()
        {
            return Boards.GetBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Update a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.PutBoardsById" />.
        /// </returns>
        public Boards.PutBoardsById PutBoardsById()
        {
            return Boards.PutBoardsById.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Remove assets from a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.DeleteAssets" />.
        /// </returns>
        public Boards.DeleteAssets DeleteAssets()
        {
            return Boards.DeleteAssets.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Add assets to a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.PutAssets" />.
        /// </returns>
        public Boards.PutAssets PutAssets()
        {
            return Boards.PutAssets.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Remove an asset from a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.DeleteAssetsById" />.
        /// </returns>
        public Boards.DeleteAssetsById DeleteAssetsById()
        {
            return Boards.DeleteAssetsById.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Add an asset to a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.PutAssetsById" />.
        /// </returns>
        public Boards.PutAssetsById PutAssetsById()
        {
            return Boards.PutAssetsById.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Get comments from a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.GetComments" />.
        /// </returns>
        public Boards.GetComments GetComments()
        {
            return Boards.GetComments.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Add a comment to a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.PostComments" />.
        /// </returns>
        public Boards.PostComments PostComments()
        {
            return Boards.PostComments.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        /// <summary>
        ///     Delete a comment from a board
        /// </summary>
        /// <returns>
        ///     The <see cref="Boards.DeleteCommentsById" />.
        /// </returns>
        public Boards.DeleteCommentsById DeleteCommentsById()
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
        public AssetLicensing.AcquireExtendedLicense AcquireExtendedLicense()
        {
            return AssetLicensing.AcquireExtendedLicense.GetInstance(_credentials, _baseUrl,  _customHandler);
        }
    }
}