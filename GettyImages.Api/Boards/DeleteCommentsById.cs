using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards
{
    public class DeleteCommentsById : ApiRequest
    {
        protected const string V3DeleteCommentByIdPath = "/boards/{0}/comments/{1}";
        protected string BoardId { get; set; }
        protected string CommentId { get; set; }

        private DeleteCommentsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static DeleteCommentsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DeleteCommentsById(credentials, baseUrl, customHandler);
        }

        public override async Task ExecuteVoidAsync()
        {
            Method = "DELETE";
            Path = string.Format(V3DeleteCommentByIdPath, BoardId, CommentId);

            await base.ExecuteVoidAsync();
        }

        public DeleteCommentsById WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public DeleteCommentsById WithCommentId(string value)
        {
            CommentId = value;
            return this;
        }

        public DeleteCommentsById WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
