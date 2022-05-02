// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetCommentsResponse
{
    public Comment[] Comments { get; set; }
    public BoardCommentPermissions Permissions { get; set; }
}