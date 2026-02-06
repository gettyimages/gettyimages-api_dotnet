// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
using System.Text.Json.Serialization;

namespace GettyImages.Api.Models;

public class ArtistAssetSearchAllowedUse
{
    [JsonPropertyName("HowCanIUseIt")] public string HowCanIUseIt { get; set; }
    [JsonPropertyName("ReleaseInfo")] public string ReleaseInfo { get; set; }
    [JsonPropertyName("UsageRestrictions")] public string[] UsageRestrictions { get; set; }
    [JsonPropertyName("Code")] public string Code { get; set; }
}
