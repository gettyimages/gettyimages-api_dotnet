using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class GetBoardsById : ApiRequest<BoardDetail>
{
    protected const string V3PostBoardsPath = "/boards";

    private GetBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }

    internal static GetBoardsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new GetBoardsById(credentials, baseUrl, customHandler);
    }

    public override async Task<BoardDetail> ExecuteAsync()
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