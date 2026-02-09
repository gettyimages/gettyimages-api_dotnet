// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class BoardBasic
{
    public string Id { get; set; }
    public int AssetCount { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateLastUpdated { get; set; }
    public string Description { get; set; }
    public Asset HeroAsset { get; set; }
    public string Name { get; set; }
    public string BoardRelationship { get; set; }
}
