using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Boards;

public class PostComments : ApiRequest<CreateCommentResponse>
{
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

    public PostComments WithBoardId(string value)
    {
        Path = $"/boards/{value}/comments";
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