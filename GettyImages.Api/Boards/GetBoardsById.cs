using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class GetBoardsById : ApiRequest
    {
        protected const string V3PostBoardsPath = "/boards";
        protected string BoardId { get; set; }

        private GetBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static GetBoardsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new GetBoardsById(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3PostBoardsPath + "/" + BoardId;

            return await base.ExecuteAsync();
        }

        public GetBoardsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public GetBoardsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
