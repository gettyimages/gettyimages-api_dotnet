// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System.Text.Json.Serialization;

namespace GettyImages.Api.Models;

public class Country
{
    [JsonPropertyName("iso_alpha_2")] public string IsoAlpha2 { get; set; }
    [JsonPropertyName("iso_alpha_3")] public string IsoAlpha3 { get; set; }
    public string Name { get; set; }
}