// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class ChangedAssetDetail
{
    public DateTime AssetChangedUtcDatetime { get; set; }
    public string AssetLifecycle { get; set; }
    public string AssetType { get; set; }
    public string Id { get; set; }
    public string Uri { get; set; }
}