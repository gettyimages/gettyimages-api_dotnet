using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class DeleteAssets : ApiRequest
    {

        protected const string V3DeleteAssetsPath = "/boards/{0}/assets";
        protected string BoardId { get; set; }

        private DeleteAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static DeleteAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DeleteAssets(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "DELETE";
            Path = string.Format(V3DeleteAssetsPath, BoardId);

            return await base.ExecuteAsync();
        }

        public DeleteAssets WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public DeleteAssets WithAssetIds(IEnumerable<string> value)
        {
            AddAssetIds(value);
            return this;
        }

        public DeleteAssets WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
