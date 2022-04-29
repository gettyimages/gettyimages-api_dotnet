using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class GetComments : ApiRequest<GetCommentsResponse>
{
    private GetComments(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
    }

    protected string BoardId { get; set; }

    internal static GetComments GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new GetComments(credentials, baseUrl, customHandler);
    }

    public GetComments WithBoardId(string value)
    {
        Path = $"/boards/{value}/comments";
        return this;
    }

    public GetComments WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}