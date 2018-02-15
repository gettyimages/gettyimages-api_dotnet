using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class DeleteBoardsById : ApiRequest
    {
        protected const string V3PostBoardsPath = "/boards";
        protected string BoardId { get; set; }

        private DeleteBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static DeleteBoardsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DeleteBoardsById(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "DELETE";
            Path = V3PostBoardsPath + "/" + BoardId;

            return await base.ExecuteAsync();
        }

        public DeleteBoardsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public DeleteBoardsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
