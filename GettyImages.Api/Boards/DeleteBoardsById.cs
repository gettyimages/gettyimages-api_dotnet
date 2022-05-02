using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Boards;

public class DeleteBoardsById : ApiRequest
{
    protected const string V3PostBoardsPath = "/boards";

    private DeleteBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }

    internal static DeleteBoardsById GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new DeleteBoardsById(credentials, baseUrl, customHandler);
    }

    public override async Task ExecuteAsync()
    {
        Method = "DELETE";
        Path = V3PostBoardsPath + "/" + BoardId;

        await base.ExecuteAsync();
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