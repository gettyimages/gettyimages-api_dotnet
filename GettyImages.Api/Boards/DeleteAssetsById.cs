using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class DeleteAssetsById : ApiRequest
    {
        protected const string V3DeleteAssetByIdPath = "/boards/{0}/assets/{1}";
        protected string BoardId { get; set; }
        protected string AssetId { get; set; }

        private DeleteAssetsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static DeleteAssetsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DeleteAssetsById(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "DELETE";
            Path = string.Format(V3DeleteAssetByIdPath, BoardId, AssetId);

            return await base.ExecuteAsync();
        }

        public DeleteAssetsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public DeleteAssetsById WithAssetId(string value)
        {
            AssetId = value;
            return this;
        }

        public DeleteAssetsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
