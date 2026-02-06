using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class GetBoardsById : ApiRequest<GetBoardDetailsResponse>
{
    private GetBoardsById(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";

    }

    internal static GetBoardsById GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new GetBoardsById(credentials, baseUrl, customHandler);
    }

    public GetBoardsById WithBoardId(string value)
    {
        Path = $"/boards/{value}";
        return this;
    }

    public GetBoardsById WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
