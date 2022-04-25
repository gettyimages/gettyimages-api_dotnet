using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards
{
    public class PostComments : ApiRequest<CreateCommentResponse>
    {
        protected const string V3PostCommentsPath = "/boards/{0}/comments";
        protected string BoardId { get; set; }

        private PostComments(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "POST";
        }

        internal static PostComments GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PostComments(credentials, baseUrl, customHandler);
        }

        public override async Task<CreateCommentResponse> ExecuteAsync()
        {
            Path = string.Format(V3PostCommentsPath, BoardId);
            return await base.ExecuteAsync();
        }

        public PostComments WithBoardId(string value)
        {
            BoardId = value;
            return this;
        }

        public PostComments WithComment(string value)
        {
            BodyParameter = new CommentRequest { Text = value };
            return this;
        }

        public PostComments WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
