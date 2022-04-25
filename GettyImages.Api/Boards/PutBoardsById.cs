using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards
{
    public class PutBoardsById : ApiRequest
    {
        protected const string V3PostBoardsPath = "/boards";
        protected string BoardId { get; set; }

        private PutBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PutBoardsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PutBoardsById(credentials, baseUrl, customHandler);
        }

        public override async Task ExecuteVoidAsync()
        {
            Method = "PUT";
            Path = V3PostBoardsPath + "/" + BoardId;

            await base.ExecuteVoidAsync();
        }

        public PutBoardsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public PutBoardsById WithBoardInfo(BoardInfo value)
        {
            BodyParameter = value;
            return this;
        }

        public PutBoardsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
