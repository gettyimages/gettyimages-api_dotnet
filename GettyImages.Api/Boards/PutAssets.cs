using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class PutAssets : ApiRequest
    {
        protected const string V3PutAssetsPath = "/boards/{0}/assets";
        protected string BoardId { get; set; }

        private PutAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PutAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PutAssets(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "PUT";
            Path = string.Format(V3PutAssetsPath, BoardId);

            return await base.ExecuteAsync();
        }

        public PutAssets WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public PutAssets WithBoardAssets(string value)
        {
            BodyParameter = value;
            return this;
        }

        public PutAssets WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
