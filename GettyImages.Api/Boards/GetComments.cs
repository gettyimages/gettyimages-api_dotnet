using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class GetComments : ApiRequest<GetCommentsResponse>
{
    protected const string V3GetCommentsPath = "/boards/{0}/comments";

    private GetComments(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string BoardId { get; set; }

    internal static GetComments GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new GetComments(credentials, baseUrl, customHandler);
    }

    public override async Task<GetCommentsResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = string.Format(V3GetCommentsPath, BoardId);

        return await base.ExecuteAsync();
    }

    public GetComments WithBoardId(string value)
    {
        BoardId = value;
        return this;
    }

    public GetComments WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}