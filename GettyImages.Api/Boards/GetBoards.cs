using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;
using BoardRelationship = GettyImages.Api.Entity.BoardRelationship;
using SortOrder = GettyImages.Api.Entity.SortOrder;

namespace GettyImages.Api.Boards
{
    public class GetBoards : ApiRequest<GetBoardsResponse>
    {
        protected const string V3GetBoardsPath = "/boards";

        private GetBoards(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static GetBoards GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new GetBoards(credentials, baseUrl, customHandler);
        }

        public override async Task<GetBoardsResponse> ExecuteAsync()
        {
            Method = "GET";
            Path = V3GetBoardsPath;

            return await base.ExecuteAsync();
        }

        public GetBoards WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public GetBoards WithBoardRelationship(BoardRelationship value)
        {
            AddQueryParameter(Constants.BoardRelationshipKey, value);
            return this;
        }

        public GetBoards WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public GetBoards WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public GetBoards WithSortOrder(SortOrder value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
            return this;
        }
    }
}
