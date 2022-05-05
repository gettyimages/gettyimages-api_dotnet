// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class GetBoardDetailsResponse
{
    public string Id { get; set; }
    public int AssetCount { get; set; }
    public Asset[] Assets { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateLastUpdated { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int CommentCount { get; set; }
    public BoardPermissions Permissions { get; set; }
    public Links Links { get; set; }
}