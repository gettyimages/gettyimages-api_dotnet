// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class Asset
{
    public string Id { get; set; }
    public string AssetType { get; set; }
    public DateTime DateAdded { get; set; }
    public DisplaySize[] DisplaySizes { get; set; }
}
