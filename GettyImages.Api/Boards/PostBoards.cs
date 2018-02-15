using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class PostBoards : ApiRequest
    {
        protected const string V3PostBoardsPath = "/boards";

        private PostBoards(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PostBoards GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PostBoards(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "POST";
            Path = V3PostBoardsPath;

            return await base.ExecuteAsync();
        }

        public PostBoards WithNewBoard(string value)
        {
            BodyParameter = value;
            return this;
        }

        public PostBoards WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
