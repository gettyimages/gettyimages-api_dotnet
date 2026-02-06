// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class Comment
{
    public Collaborator CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public string Id { get; set; }
    public CommentPermissions Permissions { get; set; }
    public string Text { get; set; }
}
