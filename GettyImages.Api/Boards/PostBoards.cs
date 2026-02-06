using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class PostBoards : ApiRequest<CreateBoardResponse>
{
    private PostBoards(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "POST";
        Path = "/boards";
    }

    internal static PostBoards GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new PostBoards(credentials, baseUrl, customHandler);
    }

    public PostBoards WithNewBoard(BoardInfo value)
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
