using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class PutAssetsById : ApiRequest
    {
        protected const string V3PutAssetByIdPath = "/boards/{0}/assets/{1}";
        protected string BoardId { get; set; }
        protected string AssetId { get; set; }

        private PutAssetsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PutAssetsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PutAssetsById(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "PUT";
            Path = string.Format(V3PutAssetByIdPath, BoardId, AssetId);

            return await base.ExecuteAsync();
        }

        public PutAssetsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public PutAssetsById WithAssetId(string value)
        {
            AssetId = value;
            return this;
        }

        public PutAssetsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
