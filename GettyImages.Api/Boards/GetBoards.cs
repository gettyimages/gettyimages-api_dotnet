using System.Net.Http;
using GettyImages.Api.Models;
using BoardRelationship = GettyImages.Api.Models.BoardRelationship;

namespace GettyImages.Api.Boards;

public class GetBoards : ApiRequest<GetBoardsResponse>
{
    private GetBoards(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/boards";
    }

    internal static GetBoards GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new GetBoards(credentials, baseUrl, customHandler);
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

    public GetBoards WithSortOrder(SortOrderEditorial value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }
}